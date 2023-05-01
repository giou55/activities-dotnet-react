using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.Activities.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }

                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Πεζοπορία νυχτερινή με πανσέληνο στο ιστορικό κέντρο της Αθήνας",
                        Date = DateTime.UtcNow.AddMonths(-2),
                        Description = @"Νυχτερινη πεζοπορία με πανσέληνο, στις 5 Μαιου 2023 Παρασκευη, στο ιστορικό κέντρο της Αθήνας περιμετρικά της Ακρόπολης,
                                    με ηλιοβασίλεμα στον Άρειο Πάγο, με πανσεληνο στο λόφο της ΠΝΥΚΑΣ. Στη συνέχεια προαιρετικα σε ταβέρνα στο μοναστηρακι..
                                    Σημείο συνάντησης σταθμός Ηλεκτρικού Θησείο και ώρα 18.54 μ.μ. Η συμμετοχή είναι δωρεάν οι συμμετέχοντες να είναι υγιείς σε καλή φυσική κατάσταση,
                                    παπούτσια κατάλληλα για χώμα, άσφαλτο, βράχια, σακίδιο νερό, καπέλο, αντιανεμικο, ξηρά τροφή.
                                    Η διαδρομή είναι περίπου 3.00 έως 3.30 ώρες.",
                        Category = "πεζοπορία",
                        City = "Αθήνα",
                        Venue = "Σταθμός μετρό Θησείου",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true
                            }
                        }
                    },
                    new Activity
                    {
                        Title = "Σεμινάριο συλλογής και διατήρησης σπόρων",
                        Date = DateTime.UtcNow.AddMonths(-1),
                        Description = @"Μέσα από παρουσιάσεις και συζητήσεις, αυτό το σεμινάριο, έχει στόχο να παράσχει μια πλήρη κατανόηση της
                            αξίας των παραδοσιακών ποικιλιών σπόρων καθώς και την απαραίτητη τεχνική εκπαίδευση στη συλλογή και τη διατήρηση τους.
                            Πραγματοποιείται διαδικτυακά (συνολική διαρκεια 8 ώρες).
                            Όσοι/ες το παρακολουθήσουν, μετά το τέλος του σεμιναρίου θα λάβουν δωρεάν ταχυδρομικά 3 παραδοσιακές ποικιλίες λαχανικών
                            από την τράπεζα σπόρων της Νέας Γουινέας για να εξασκήσουν τις γνώσεις που απέκτησαν! Επίσης θα λάβουν τις παρουσιάσεις
                            του σεμιναρίου και πολύ επιπλέον υλικό για διάβασμα. Κόστος συμμετοχής: 40 ευρώ.",
                        Category = "σεμινάριο",
                        City = "Everywhere",
                        Venue = "Online",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = false
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "Φαντάσματα Εφηβείας (Ghost World) // Τέρι Ζουίγκοφ",
                        Date = DateTime.UtcNow.AddMonths(1),
                        Description = @"Αυτή την εβδομάδα στο Cinemarian, μία όχι και τόσο συνηθισμένη teen movie, βασισμένη στο ομότιτλο κόμικ του Ντάνιελ Κλόουζ.
                            Δεν κάνουμε κρατήσεις, τα εισιτήρια μπορείτε να τα προμηθευτείτε από το ταμείο μας πριν την προβολή. Τηρείται η σειρά προτεραιότητας.",
                        Category = "φιλμ",
                        City = "Αθήνα",
                        Venue = "Cinemarian, Σισμάνη 16",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = false
                            },
                        }
                    },
                    new Activity
                    {
                        Title = "ΕΥΡΥΔΙΚΗ – ΜΠΛΕ Ζήσε τη στιγμή!",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"Η Ευρυδίκη και οι Μπλε μας προτρέπουν: Ζήστε μαζί μας τη στιγμή!
                            Ύστερα από αλλεπάλληλες sοld out εμφανίσεις σε Αθήνα, Θεσσαλονίκη και Κύπρο, η Ευρυδίκη και οι Μπλε έρχονται για να βάλουν φωτιά στη σκηνή του CT Garden.
                            Οι δύο πιο ξεχωριστές ποπ-ροκ φωνές της ελληνικής μουσικής, η Ευρυδίκη και η Τζώρτζια αποτελούν ένα εκρηκτικό μείγμα γεμάτο εξωστρέφεια και φρεσκάδα.
                            Η καταξιωμένη Ευρυδίκη, με μακρόχρονη πορεία στο τραγούδι, που διακρίνεται για το ηχόχρωμα της φωνής της και τις ανατρεπτικές συνεργασίες,
                            μαζί με το ξεχωριστό συγκρότημα των Μπλε,
                            με την ιδιαίτερη αισθητική στη μουσική και στον στίχο και την πολυεπίπεδη “front woman” Τζώρτζια Κεφαλά, συνεργάζονται συναυλιακά και δισκογραφικά.
                            “Άκου την Ζωή” είναι ο τίτλος του ντουέτου τους που κυκλοφόρησε πρόσφατα με τις φωνές της Ευρυδίκης και της Τζώρτζιας, σε μουσική Γιώργου Παπαποστόλου,
                            συνθέτη και παραγωγού των Μπλε και στίχους του Γιώργου Παρώδη.
                            Η Ευρυδίκη και οι Μπλε σε αυτήν τη μουσική συνάντηση στο CT Garden θα μας παρουσιάσουν τα αγαπημένα τους τραγούδια και μια σειρά από ντουέτα “έκπληξη”,
                            ελληνικά και ξένα, χωρίς να λείπουν φυσικά όλες οι μεγάλες τους επιτυχίες.",
                        Category = "μουσική",
                        City = "Αθήνα",
                        Venue = "Christmas Theater",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[0],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[2],
                                IsHost = false
                            },
                        }
                    }
                };

                await context.Activities.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }
}
