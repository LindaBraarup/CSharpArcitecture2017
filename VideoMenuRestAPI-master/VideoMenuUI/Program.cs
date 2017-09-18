using System;
using VideoMenuBLL;
using VideoMenuBLL.BusinessObjects;
using static System.Console;

namespace VideoMenuUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();


        static void Main()
        {
            //Making a new Video
            VideoBO v = new VideoBO();


            #region Hardcoded data for testing
            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "HangoBongo Returns"
            });


            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "The incredible Kerv (Full movie, no fake)"
            });
            #endregion //Hardcoded data for testing


            #region Menu Items
            string[] menuItems =
            {
                "Home",
                "Video List",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };
            #endregion

            #region Menu Switch

            // Show Menu
            WriteLine("What are we watching today?");
            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {

                switch (selection)
                {
                    case 1:
                        WriteLine("Home");
                        WriteLine("All available options:");
                        ShowMenu(menuItems);
                        break;
                    case 2:
                        ListVideos();
                        break;
                    case 3:
                        WriteLine("Add Video");
                        while (AddVideos())
                        {
                            WriteLine("Adding a new video...\n");
                        }
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    case 5:
                        EditVideo();
                        break;
                    default:
                        break;

                }
                WriteLine("----------------------");
                selection = ShowMenu(menuItems);
                WriteLine("----------------------");
            }

            WriteLine("See you soon!\n");
            WriteLine("----------------------");
            WriteLine("Press any key...\n");
            ReadKey();
            Environment.Exit(0);


        }

        #endregion

        #region Display all menu items and read user input

        private static int ShowMenu(string[] menuItems)
        {

            WriteLine("");

            for (var i = 0; i < menuItems.Length; i++)
            {
                WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            WriteLine("");
            Write("Choose one: ");


            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
            {
                WriteLine("\nYou need to select a number between 1 and 5!");
                Write("Choose one: ");
            }
            WriteLine("\nSelected: " + selection);
            WriteLine("----------------------");

            return selection;
        }
        #endregion

        #region List all Videos

        private static void ListVideos()
        {
            WriteLine("\nList of Videos:\n");
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                WriteLine($"{(video.Id)}: {video.Title}");
            }
            WriteLine("\n");
        }

        #endregion

        #region Find one Video

        private static VideoBO FindVideoById()
        {
            WriteLine("Insert Video number: ");
            int id;
            while (!int.TryParse(ReadLine(), out id))
            {
                WriteLine("Please insert a number");
            }


            return bllFacade.VideoService.Get(id);
        }

        #endregion //Find Video

        #region CREATE

        private static bool AddVideos()
        {
            Write("Video Title: ");
            var title = ReadLine();

            if (!string.IsNullOrEmpty(title))
            {
                // Call BLL Facade to add video
                bllFacade.VideoService.Create(new VideoBO()
                {
                    Title = title
                });
                WriteLine("Video added!");
                Write("\nDo you want to Add another video? [Y], or press any key...");
                /// <summary>Another possibility</summary>
                //var input = ReadLine().ToLower();
                //if (input == "y")
                //{
                //    return true;
                //}
                //else if (input == "n")
                //{

                //    return false;
                //}
                ///
                return ReadLine().ToLower() == "y";
            }

            return true;
        }
        #endregion //Add Videos

        #region DELETE


        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();

            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            var response = videoFound == null ? "Video not found!" : "Video was deleted!";
            WriteLine(response);
        }


        #endregion //Delete Videos

        #region UPDATE

        private static void EditVideo()
        {
            var video = FindVideoById();
            if (video != null)
            {
                Write("\nVideo Title: ");
                video.Title = ReadLine();
                WriteLine("Video has been updated!");
                bllFacade.VideoService.Update(video);
            }
            else
            {
                WriteLine("Video not found!");
            }

        }

        #endregion //Edit Video
    }
}

