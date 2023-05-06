using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(
            DataContext context,
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
                    await userManager.CreateAsync(user, "123456");
                }

                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Πεζοπορία νυχτερινή με πανσέληνο στο ιστορικό κέντρο της Αθήνας",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = @"<p>Νυχτερινή πεζοπορία με πανσέληνο, στις 25 Μαιου 2023 Παρασκευή, στο ιστορικό κέντρο της Αθήνας περιμετρικά της <b>Ακρόπολης</b>,
                                    με ηλιοβασίλεμα στον <b>Άρειο Πάγο</b>, με πανσέληνο στο λόφο της <b>Πνύκας</b>. Στη συνέχεια προαιρετικά σε ταβέρνα στο μοναστηράκι.</p>
                                    <p>Σημείο συνάντησης σταθμός Ηλεκτρικού Θησείο και ώρα 18.54 μ.μ.</p>
                                    <p>Η συμμετοχή είναι δωρεάν, οι συμμετέχοντες να είναι υγιείς σε καλή φυσική κατάσταση,
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
                                αξίας των παραδοσιακών ποικιλιών σπόρων καθώς και την απαραίτητη τεχνική εκπαίδευση στη συλλογή και τη διατήρηση τους.<br>
                                Πραγματοποιείται διαδικτυακά (συνολική διαρκεια 8 ώρες).</p>
                                <p>Όσοι/ες το παρακολουθήσουν, μετά το τέλος του σεμιναρίου θα λάβουν δωρεάν ταχυδρομικά 3 παραδοσιακές ποικιλίες λαχανικών
                                από την τράπεζα σπόρων της Νέας Γουινέας για να εξασκήσουν τις γνώσεις που απέκτησαν! Επίσης θα λάβουν τις παρουσιάσεις
                                του σεμιναρίου και πολύ επιπλέον υλικό για διάβασμα.<br>Κόστος συμμετοχής: 40 ευρώ.</p>",
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
                        Description = @"<p>Σας περιμένουμε στο σεμινάριο μας <b>'Πως να παρακινήσουμε τα παιδιά να αγαπήσουν το διάβασμα'</b>
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
                        Description = @"<p>Αυτή την εβδομάδα στο Cinemarian, μία όχι και τόσο συνηθισμένη teen movie, βασισμένη στο ομότιτλο κόμικ του <b>Ντάνιελ Κλόουζ</b>.</p>
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
                        Description = @"<p>Η <b>Ευρυδίκη</b> και οι <b>Μπλε</b> μας προτρέπουν: Ζήστε μαζί μας τη στιγμή!
                                    Ύστερα από αλλεπάλληλες sοld out εμφανίσεις σε Αθήνα, Θεσσαλονίκη και Κύπρο, η Ευρυδίκη και οι Μπλε έρχονται για να βάλουν φωτιά στη σκηνή του CT Garden.
                                    Οι δύο πιο ξεχωριστές ποπ-ροκ φωνές της ελληνικής μουσικής, η Ευρυδίκη και η Τζώρτζια αποτελούν ένα εκρηκτικό μείγμα γεμάτο εξωστρέφεια και φρεσκάδα.</p>
                                    <p>Η καταξιωμένη <b>Ευρυδίκη</b>, με μακρόχρονη πορεία στο τραγούδι, που διακρίνεται για το ηχόχρωμα της φωνής της και τις ανατρεπτικές συνεργασίες,
                                    μαζί με το ξεχωριστό συγκρότημα των Μπλε, με την ιδιαίτερη αισθητική στη μουσική και στον στίχο και την πολυεπίπεδη “front woman” <b>Τζώρτζια Κεφαλά</b>,
                                    συνεργάζονται συναυλιακά και δισκογραφικά.</p>
                                    <p><b>“Άκου την Ζωή”</b> είναι ο τίτλος του ντουέτου τους που κυκλοφόρησε πρόσφατα με τις φωνές της Ευρυδίκης και της Τζώρτζιας, σε μουσική <b>Γιώργου Παπαποστόλου</b>,
                                    συνθέτη και παραγωγού των Μπλε και στίχους του <b>Γιώργου Παρώδη</b>.<br>
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
                    },
                    new Activity
                    {
                        Title = "Έκθεση Φωτογραφίας - Captivity",
                        Date = DateTime.UtcNow.AddMonths(3),
                        Description = @"<p>Η φωτογράφος εμπνευσμένη από τα γεγονότα στη χώρα της ευρύτερης γειτονιάς μας, το Ιράν,
                                    προχώρησε στη δημιουργία της φωτογραφικής της έκθεσης. Το έργο δημιουργήθηκε για να αναδείξει
                                    την καταπίεση και τη βία που δέχονται οι γυναίκες σε όλα τα μήκη και πλάτη της γης, από ένα
                                    σύστημα που φοβάται την ομορφιά, την έμπνευση, και τη δημιουργικότητά της.</p>
                                    <p>Μέσα από το φωτογραφικό της πρίσμα, θέλει να επικοινωνήσει προς όλο τον κόσμο ότι τα μαλλιά
                                    μας μπορούν να γίνουν μαντήλα, φερεντζές, αλλά και δύναμη στα χέρια μας. Είναι μία πρόσκληση,
                                    δίνοντας τους το χέρι μας, να ενωθούμε όλοι μαζί και να συνεχίσει ο αγώνας για μία κοινωνία
                                    δίκαιη και ισότιμη.</p>
                                    <p>Εγκαίνια: Σάββατο 06 Μαΐου στις 20:00</p>
                                    <p>Διάρκεια Φωτογραφικής Έκθεσης: 06 – 20.05.203<br>
                                    Ώρες λειτουργίας: 12:00 – 21:00<br>
                                    Τοποθεσία: Κέντρο Νεότητας - Δήμου Χαλανδρίου, Αντιγόνης και Δαναΐδων,
                                    Χαλάνδρι (πρόσβαση από Μετρό Νομισματοκοπείου).</p>",
                        Category = "excibition",
                        City = "Χαλάνδρι",
                        Venue = "Κέντρο Νεότητας, Αντιγόνης και Δαναΐδων",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[1],
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
                        Title = "Athens Street Food Festival 2023",
                        Date = DateTime.UtcNow.AddMonths(3),
                        Description = @"<p>Το 6o Athens Street Food Festival έρχεται τον Μάϊο και αναζητά τις καλύτερες γεύσεις από ολόκληρο τον Γαλαξία!</p>
                                    <p>Όταν ξεκίνησε το Athens Street Food Festival το 2016, η έννοια του <b>street food</b> στην Ελλάδα ήταν πρακτικά ανύπαρκτη.
                                    Όμως, η μεγάλη επιτυχία του φεστιβάλ ήταν τόσο εντυπωσιακή, ώστε να προκαλέσει ένα ολόκληρο ρεύμα,
                                    με αμέτρητα μαγαζιά και chefs σε όλη τη χώρα να προτείνουν πλέον το δικό τους φαγητό του δρόμου!</p>
                                    <p>Στο φετινό, <b>6ο Athens Street Food Festival</b>, ο στόχος μας είναι η παρουσίαση μοναδικών και ιδιαίτερων γεύσεων
                                    από κάθε γωνιά του γευστικού μας Γαλαξία! Κάθε χώρα, κάθε περιοχή, κάθε πόλη έχει τη δική της κουζίνα και
                                    αυτό το δικό της γευστικό μυστικό που μπορεί να φαγωθεί “στο δρόμο”.</p>
                                    <p>Δηλώσεις Συμμετοχής / Πληροφορίες<br>
                                    τηλ. 210-9636489</p>",
                        Category = "food",
                        City = "Αθήνα",
                        Venue = "Παλιό Αμαξοστάσιο Ο.ΣΥ - Γκάζι",
                        Attendees = new List<ActivityAttendee>
                        {
                            new ActivityAttendee
                            {
                                AppUser = users[1],
                                IsHost = true
                            },
                            new ActivityAttendee
                            {
                                AppUser = users[0],
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
