using System;
using System.Linq;
using Market.BusinessModel.Internal;
using Market.BusinessModel.Requests;
using Market.BusinessModel.Models;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Enums;

namespace Market.ConsoleVisualInterface
{
    internal static class Program
    {
        private static ServiceFactory _serviceFactory = new ServiceFactory();

        private static IClientService _clientService;

        private static void Main()
        {
            Console.WriteLine("Market Console — connecting services...");

            // Create services using the ServiceFactory
            _clientService = _serviceFactory.CreateClientService();

            RunMainLoop();
        }

        private static void RunMainLoop()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Select resource:");
                Console.WriteLine("1) Clients");
                Console.WriteLine("Q) Quit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine()?.Trim();

                switch (choice?.ToUpperInvariant())
                {
                    case "1":
                        RunClientsMenu();
                        break;
                    case "Q":
                        return;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }

        private static void RunClientsMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Clients — choose action:");
                Console.WriteLine("1) List all");
                Console.WriteLine("2) Query (filter / sort / page)");
                Console.WriteLine("3) Get by Id");
                Console.WriteLine("4) Create");
                Console.WriteLine("5) Update");
                Console.WriteLine("6) Delete");
                Console.WriteLine("B) Back");
                Console.Write("Choice: ");
                var c = Console.ReadLine()?.Trim();

                switch (c?.ToUpperInvariant())
                {
                    case "1":
                        ListAllClients();
                        break;
                    case "2":
                        QueryClientsInteractive();
                        break;
                    case "3":
                        GetClientById();
                        break;
                    case "4":
                        CreateClientInteractive();
                        break;
                    case "5":
                        UpdateClientInteractive();
                        break;
                    case "6":
                        DeleteClientInteractive();
                        break;
                    case "B":
                        return;
                    default:
                        Console.WriteLine("Unknown option.");
                        break;
                }
            }
        }

        private static void ListAllClients()
        {
            var list = _clientService.GetClients(new ClientQuery());
            PrintClients(list);
        }

        private static void QueryClientsInteractive()
        {
            var q = new ClientQuery();

            Console.Write("Name contains (leave empty for no filter): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) q.Name = name;

            Console.Write("Email equals (leave empty for no filter): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) q.Email = email;

            Console.Write("Sort by (Name / Email / CreatedAt) or leave empty: ");
            var sort = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sort) && Enum.TryParse<ClientSortBy>(sort, true, out var s))
            {
                q.SortBy = s;
                Console.Write("Sort direction (Asc / Desc) [Asc]: ");
                var dir = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(dir) && Enum.TryParse<Market.BusinessModel.Enums.SortDirection>(dir, true, out var d))
                    q.SortDirection = d;
            }

            Console.Write("Page (1-based, leave empty for all): ");
            var pageText = Console.ReadLine();
            Console.Write("PageSize (leave empty for all): ");
            var pageSizeText = Console.ReadLine();
            if (int.TryParse(pageText, out var page) && int.TryParse(pageSizeText, out var pageSize))
            {
                q.Page = page;
                q.PageSize = pageSize;
            }

            var result = _clientService.GetClients(q);
            PrintClients(result);
        }

        private static void GetClientById()
        {
            Console.Write("Id: ");
            var id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Id required.");
                return;
            }

            var repo = _serviceFactory.CreateClientService(); // we need repo-level GetById via service's underlying repo
            // IClientService does not expose GetById; access repository directly via a RepositoryFactory if needed.
            // For convenience use Query with Ids:
            var list = _clientService.GetClients(new ClientQuery { Ids = new System.Collections.Generic.List<string> { id } });
            var item = list.FirstOrDefault();
            if (item == null)
            {
                Console.WriteLine("Not found.");
                return;
            }

            PrintClient(item);
        }

        private static void CreateClientInteractive()
        {
            var client = new ClientModel();

            Console.Write("Name: ");
            client.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            client.Email = Console.ReadLine() ?? string.Empty;

            Console.Write("PhoneNumber: ");
            client.PhoneNumber = Console.ReadLine() ?? string.Empty;

            // Save will call Add or Update depending on Id existence — here Add
            _clientService.CreateClient(client);

            Console.WriteLine("Created (check DB for assigned Id).");
        }

        private static void UpdateClientInteractive()
        {
            Console.Write("Id of client to update: ");
            var id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Id required.");
                return;
            }

            var existing = _clientService.GetClients(new ClientQuery { Ids = new System.Collections.Generic.List<string> { id } }).FirstOrDefault();
            if (existing == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.WriteLine("Leave field empty to keep current value.");
            Console.Write($"Name ({existing.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) existing.Name = name;

            Console.Write($"Email ({existing.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) existing.Email = email;

            Console.Write($"PhoneNumber ({existing.PhoneNumber}): ");
            var phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone)) existing.PhoneNumber = phone;

            _clientService.UpdateClient(existing);
            Console.WriteLine("Updated.");
        }

        private static void DeleteClientInteractive()
        {
            Console.Write("Id of client to delete: ");
            var id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Id required.");
                return;
            }

            var existing = _clientService.GetClients(new ClientQuery { Ids = new System.Collections.Generic.List<string> { id } }).FirstOrDefault();
            if (existing == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.Write("Confirm delete (y/N): ");
            var conf = Console.ReadLine();
            if (!string.Equals(conf, "y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Cancelled.");
                return;
            }

            _clientService.DeleteClient(existing);
            Console.WriteLine("Deleted.");
        }

        private static void PrintClients(System.Collections.Generic.List<ClientModel> list)
        {
            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No clients found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"Found {list.Count} clients:");
            foreach (var c in list)
            {
                PrintClient(c);
            }
        }

        private static void PrintClient(ClientModel c)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Id: {c.Id}");
            Console.WriteLine($"Name: {c.Name}");
            Console.WriteLine($"Email: {c.Email}");
            Console.WriteLine($"Phone: {c.PhoneNumber}");
            Console.WriteLine($"CreatedAt: {c.CreatedAt}");
            Console.WriteLine($"UpdatedAt: {c.UpdatedAt}");
        }
    }
}
