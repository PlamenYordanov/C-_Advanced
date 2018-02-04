namespace PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var peopleNames = Console.ReadLine()
                .Split(new[] { ' ' }
            , StringSplitOptions.RemoveEmptyEntries);
            var partyList = new List<Person>();
            PopulatePartyList(peopleNames, partyList);
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "Party!")
            {
                var tokens = input.Split();
                string doubleOrRemove = tokens[0];
                string command = tokens[1];
                Predicate<Person> filter = null;

                switch (command.ToLower())
                {
                    case "startswith":
                        string startsOrEndsWith = tokens[2];
                        filter = s  => s.Name.StartsWith(startsOrEndsWith);
                        break;
                    case "endswith":
                        startsOrEndsWith = tokens[2];
                        filter = s => s.Name.EndsWith(startsOrEndsWith);
                        break;
                    case "length":
                        int length = int.Parse(tokens[2]);
                        filter = s => s.Name.Length.Equals(length);
                        break;
                    default:
                        break;
                }
                switch (doubleOrRemove.ToLower())
                {
                    case "double":
                        var matchingPeople = partyList.FindAll(filter);
                        DoublePeople(partyList, matchingPeople);
                        break;
                    case "remove":
                        partyList.RemoveAll(filter);
                        break;
                    default:
                        break;
                }
            }
            bool isEmpty = partyList.Count == 0;
            string emptyList = $"Nobody is going to the party!";
            string notEmptyList = $"are going to the party!";
            var people = partyList.Select(p => p.Name).ToArray();
            Console.WriteLine(isEmpty ? emptyList : $"{string.Join(", ", partyList)} {notEmptyList}");
        }

        private static void DoublePeople(List<Person> partyList, List<Person> matchingPeople)
        {
            foreach (var person in matchingPeople)
            {
                var tempPerson = new Person(person.Name);
                partyList.Add(tempPerson);
            }
        }

        private static void PopulatePartyList(string[] peopleNames, List<Person> peopleGoingToParty)
        {
            foreach (var p in peopleNames)
            {
                var person = new Person(p);
                peopleGoingToParty.Add(person);
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }
        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
