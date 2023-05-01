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
                        DisplayName = "Μιχάλης",
                        UserName = "michael",
                        Email = "michael@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Χριστίνα",
                        UserName = "christine",
                        Email = "christine@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Γιώργος",
                        UserName = "george",
                        Email = "george@test.com"
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
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"<p>Νυχτερινή πεζοπορία με πανσέληνο, στις 25 Μαιου 2023 Παρασκευή, στο ιστορικό κέντρο της Αθήνας περιμετρικά της Ακρόπολης,
                                    με ηλιοβασίλεμα στον Άρειο Πάγο, με πανσέληνο στο λόφο της Πνύκας. Στη συνέχεια προαιρετικα σε ταβέρνα στο μοναστηρακι. /n
                                    Σημείο συνάντησης σταθμός Ηλεκτρικού Θησείο και ώρα 18.54 μ.μ.</p>
                                    <p>Η συμμετοχή είναι δωρεάν οι συμμετέχοντες να είναι υγιείς σε καλή φυσική κατάσταση,
                                    παπούτσια κατάλληλα για χώμα, άσφαλτο, βράχια, σακίδιο νερό, καπέλο, αντιανεμικο, ξηρά τροφή.
                                    Η διαδρομή είναι περίπου 3.00 έως 3.30 ώρες.</p>",
                        Category = "hiking",
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
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"<p>Μέσα από παρουσιάσεις και συζητήσεις, αυτό το σεμινάριο, έχει στόχο να παράσχει μια πλήρη κατανόηση της
                                αξίας των παραδοσιακών ποικιλιών σπόρων καθώς και την απαραίτητη τεχνική εκπαίδευση στη συλλογή και τη διατήρηση τους.
                                Πραγματοποιείται διαδικτυακά (συνολική διαρκεια 8 ώρες).</p>
                                <p>Όσοι/ες το παρακολουθήσουν, μετά το τέλος του σεμιναρίου θα λάβουν δωρεάν ταχυδρομικά 3 παραδοσιακές ποικιλίες λαχανικών
                                από την τράπεζα σπόρων της Νέας Γουινέας για να εξασκήσουν τις γνώσεις που απέκτησαν! Επίσης θα λάβουν τις παρουσιάσεις
                                του σεμιναρίου και πολύ επιπλέον υλικό για διάβασμα. Κόστος συμμετοχής: 40 ευρώ.</p>",
                        Category = "seminar",
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
                        Title = "Πως να Παρακινήσουμε Τα Παιδιά Να Αγαπήσουν Το Διάβασμα",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"<p>Σας περιμένουμε στο σεμινάριο μας 'Πως να παρακινήσουμε τα παιδιά να αγαπήσουν το διάβασμα'
                                που θα πραγματοποιηθεί την Δευτέρα 18 Μαϊου στις 20:00 μ.μ.</p>
                                <p>Γονείς και εκπαιδευτικοί θέλουμε τα παιδιά μας να είναι χαρούμενα, να αγαπούν την μάθηση και να προοδεύουν.
                                Πως ο τρόπος που μιλάμε στα παιδιά και οι τεχνικές εμψύχωσεις που χρησιμοποιούμε επηρεάζουν τον τρόπο
                                που σκέφτονται και την στάση τους για την μάθηση και το σχολείο; Με ποιο τρόπο μπορούμε να βοηθήσουμε
                                τα παιδιά να βλέπουν την μάθηση σαν ένα δώρο που θα τους οδηγήσει στην πρόοδο και στην επιτυχία και
                                όχι σαν τον λόγο της δυστυχίας τους;</p>
                                <p>Στο σεμινάριο μας θα βρείτε τις απαντήσεις που αναζητάτε!</p>
                                <p>Σας περιμένουμε!</p>",
                        Category = "seminar",
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
                        Description = @"<p>Αυτή την εβδομάδα στο Cinemarian, μία όχι και τόσο συνηθισμένη teen movie, βασισμένη στο ομότιτλο κόμικ του Ντάνιελ Κλόουζ.</p>
                                    <p>Δεν κάνουμε κρατήσεις, τα εισιτήρια μπορείτε να τα προμηθευτείτε από το ταμείο μας πριν την προβολή. Τηρείται η σειρά προτεραιότητας.</p>
                                    <p>Λίγα λόγια για την ταινία...</p>
                                    <p>Σκηνοθεσία: Τέρι Ζουίγκοφ</p>
                                    <p>Πρωταγωνιστούν: Θόρα Μπερτς, Σκάρλετ Τζοχάνσον, Στιβ Μπουσέμι</p>
                                    <p>Η Ίνιντ κι η Ρεμπέκα είναι κολλητές φίλες, δυο ξεχωριστά κορίτσια που νιώθουν ότι δεν ταιριάζουν στο περιβάλλον της μικρής αμερικανικής πόλης όπου ζουν.
                                    Όταν η Ίνιντ θ’ αποφασίσει να βοηθήσει τον αρκετά μεγαλύτερο Σίμορ να βελτιώσει την ερωτική του ζωή, η σχέση των κοριτσιών θα κλονιστεί,
                                    αλλά και θα μπλεχτούν σε μια περιπέτεια από την οποία ούτε ο κυνισμός, ούτε η εξυπνάδα τους θα τις βοηθήσει να βγουν.</p>",
                        Category = "film",
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
                        Description = @"<p>Η Ευρυδίκη και οι Μπλε μας προτρέπουν: Ζήστε μαζί μας τη στιγμή!
                                    Ύστερα από αλλεπάλληλες sοld out εμφανίσεις σε Αθήνα, Θεσσαλονίκη και Κύπρο, η Ευρυδίκη και οι Μπλε έρχονται για να βάλουν φωτιά στη σκηνή του CT Garden.
                                    Οι δύο πιο ξεχωριστές ποπ-ροκ φωνές της ελληνικής μουσικής, η Ευρυδίκη και η Τζώρτζια αποτελούν ένα εκρηκτικό μείγμα γεμάτο εξωστρέφεια και φρεσκάδα.</p>
                                    <p>Η καταξιωμένη Ευρυδίκη, με μακρόχρονη πορεία στο τραγούδι, που διακρίνεται για το ηχόχρωμα της φωνής της και τις ανατρεπτικές συνεργασίες,
                                    μαζί με το ξεχωριστό συγκρότημα των Μπλε, με την ιδιαίτερη αισθητική στη μουσική και στον στίχο και την πολυεπίπεδη “front woman” Τζώρτζια Κεφαλά,
                                    συνεργάζονται συναυλιακά και δισκογραφικά.</p>
                                    <p>“Άκου την Ζωή” είναι ο τίτλος του ντουέτου τους που κυκλοφόρησε πρόσφατα με τις φωνές της Ευρυδίκης και της Τζώρτζιας, σε μουσική Γιώργου Παπαποστόλου,
                                    συνθέτη και παραγωγού των Μπλε και στίχους του Γιώργου Παρώδη.<br>
                                    Η Ευρυδίκη και οι Μπλε σε αυτήν τη μουσική συνάντηση στο CT Garden θα μας παρουσιάσουν τα αγαπημένα τους τραγούδια και μια σειρά από ντουέτα “έκπληξη”,
                                    ελληνικά και ξένα, χωρίς να λείπουν φυσικά όλες οι μεγάλες τους επιτυχίες.</p>",
                        Category = "music",
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
                    },
                    new Activity
                    {
                        Title = "Οι Χατ Τρικ στο WE",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"<p>Μετά το τελευταίο τους καταστροφικό SOLD OUT οι ΧΑΤ ΤΡΙΚ επιστρέφουν στη σκηνή του WE, κουβαλώντας στους ώμους τους το ροκ εν ρολ του δρόμου.
                                    Ξεκούρδιστες κιθάρες, πανκ ροκ μελωδίες και αντικοινωνικά στιχάκια. Κλασικοί ΧΑΤ ΤΡΙΚ.</p>
                                    <p>Προπώληση : 10 ευρώ (viva.gr & πολυχώρος WE)<br>
                                    Ταμείο : 12 ευρώ</p>",
                        Category = "music",
                        City = "Γρηγορίου Λαμπράκη 58, Θεσσαλονίκη",
                        Venue = "WE",
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
