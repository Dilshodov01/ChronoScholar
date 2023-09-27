using ChronoScholar.Service.Dto.SellerDto;
using ChronoScholar.Service.Dto.TextbookDto;
using ChronoScholar.Service.Dto.UserDto;
using ChronoScholar.Service.Interfaces.Seller;
using ChronoScholar.Service.Interfaces.Textbook;
using ChronoScholar.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChronoScholar.Presentation.UI
{
    public class UIDisplay
    {
        SellerForCreationDto sellerForCreationDto = new SellerForCreationDto();
        SellerForResultDto sellerForResultDto = new SellerForResultDto();
        SellerForUpdateDto sellerForUpdateDto = new SellerForUpdateDto();
        SellerService sellerService = new SellerService();

        UserForCreationDto userForCreationDto = new UserForCreationDto();
        UserForResultDto uSerForResultDto = new UserForResultDto();
        UserForUpdateDto userForUpdateDto = new UserForUpdateDto();
        UserService userService = new UserService();

        TextbookForCreationDto textbookCreationDto = new TextbookForCreationDto();
        TextbookForResultDto textbookForResultDto = new TextbookForResultDto();
        TextbookForUpdateDto textbookForUpdateDto = new TextbookForUpdateDto();
        TextbookService textbookService = new TextbookService();
        public void DisplayRunMethod()
        {
            


            bool closeWindow = true;
            while (closeWindow)
            {
                Console.WriteLine("1: User");
                Console.WriteLine("2: Seller");
                Console.WriteLine("3: Textbook");

                int selection = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        {
                            bool closeUserWindow = true;
                            while (closeUserWindow)
                            {
                                Console.WriteLine("1: create user");
                                Console.WriteLine("2: update user");
                                Console.WriteLine("3: delete user");
                                Console.WriteLine("4: getbyId user");
                                Console.WriteLine("5: getAll users");
                                Console.WriteLine("6: Close Window");

                                int selecion = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (selecion)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Name");
                                            userForCreationDto.Name = Console.ReadLine();

                                            Console.WriteLine("Phone");
                                            userForCreationDto.PhoneNumber = Console.ReadLine();

                                            Console.WriteLine("Email");
                                            userForCreationDto.Email = Console.ReadLine();

                                            Console.WriteLine("Pasword");
                                            userForCreationDto.Password = Console.ReadLine();

                                            Console.WriteLine("Lacation");
                                            userForCreationDto.Lacation = Console.ReadLine();

                                            var data=userService.CreateAsync(userForCreationDto);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} | {data.Result.PhoneNumber} |  {data.Result.Lacation}");


                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("ID ");
                                            userForUpdateDto.Id=long.Parse(Console.ReadLine());

                                            Console.WriteLine("Name");
                                            userForUpdateDto.Name = Console.ReadLine();

                                            Console.WriteLine("Phone");
                                            userForUpdateDto.PhoneNumber = Console.ReadLine();

                                            Console.WriteLine("Lacation");
                                            userForUpdateDto.Lacation = Console.ReadLine();

                                            var data=userService.UpdateAsync(userForUpdateDto);

                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} | {data.Result.PhoneNumber} |  {data.Result.Lacation}\n\n");


                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("ID ");
                                            long Id = long.Parse(Console.ReadLine());
                                            var remove = userService.RemoveAsync(Id);

                                            Console.WriteLine(remove);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("ID ");
                                            long Id = long.Parse(Console.ReadLine());

                                            var data =userService.GetByIdAsync(Id);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} | {data.Result.PhoneNumber} |  {data.Result.Lacation}\n\n");

                                            break;
                                        }
                                        case 5:
                                        {
                                            var data= userService.GetAllAsync();
                                            foreach ( var item in data.Result )
                                            {
                                                Console.WriteLine($"{item.Id} | {item.Name} | {item.PhoneNumber} |  {item.Lacation}\n\n");

                                            }
                                            break;
                                        }
                                        case 6:
                                        {
                                            closeUserWindow = false;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            bool SellerWindow = true;

                            while (SellerWindow)
                            {


                                Console.WriteLine("\n\n1: create Seller");
                                Console.WriteLine("2: update Seller");
                                Console.WriteLine("3: delete Seller");
                                Console.WriteLine("4: getbyId Seller");
                                Console.WriteLine("5: getAll Seller");
                                Console.WriteLine("6: Close Seller\n\n");

                                int selecion = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (selecion)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Name");
                                            sellerForCreationDto.Name = Console.ReadLine();

                                            Console.WriteLine("Email");
                                            sellerForCreationDto.Email = Console.ReadLine();

                                            Console.WriteLine("Pasword");
                                            userForCreationDto.Password = Console.ReadLine();

                                            var data = sellerService.CreateAsync(sellerForCreationDto);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} |\n\n");
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Id");
                                            long id = int.Parse(Console.ReadLine());

                                            Console.WriteLine("Name");
                                            sellerForUpdateDto.Name = Console.ReadLine();

                                            var data = sellerService.UpdateAsync(sellerForUpdateDto);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} |\n\n");

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Id");
                                            long id = int.Parse(Console.ReadLine());

                                            Console.WriteLine(sellerService.RemoveAsync(id));

                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Id");
                                            long id = long.Parse(Console.ReadLine());

                                            var data = sellerService.GetByIdAsync(id);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Name} |\n\n");

                                            break;
                                        }
                                    case 5:
                                        {
                                            var data = sellerService.GetAllAsync();
                                            foreach (var item in data.Result)
                                            {
                                                Console.WriteLine($"{item.Id} | {item.Name} |");

                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            SellerWindow = false;
                                            break;
                                        }
                                }
                            }

                            break;
                        }
                    case 3:
                        {
                            bool TextbookWindow = true;
                            while (TextbookWindow)
                            {


                                Console.WriteLine("1: create textbook");
                                Console.WriteLine("2: update textbook");
                                Console.WriteLine("3: delete textbook");
                                Console.WriteLine("4: getbyId textbook");
                                Console.WriteLine("5: getAll textbooks");
                                Console.WriteLine("6: Close Window");

                                int selecion = int.Parse(Console.ReadLine());
                                Console.Clear();
                                switch (selecion)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("User Id");
                                            textbookCreationDto.UserId = long.Parse(Console.ReadLine());

                                            Console.WriteLine("Seller Id");
                                            textbookCreationDto.SellerId = long.Parse(Console.ReadLine());

                                            Console.WriteLine("Email");
                                            textbookCreationDto.Email = Console.ReadLine();

                                            Console.WriteLine("Price");
                                            textbookCreationDto.Price = decimal.Parse(Console.ReadLine());

                                            Console.WriteLine("Title");
                                            textbookCreationDto.Title = Console.ReadLine();

                                            Console.WriteLine("Author");
                                            textbookCreationDto.Author = Console.ReadLine();

                                            Console.WriteLine("Description");
                                            textbookCreationDto.Description = Console.ReadLine();

                                            Console.WriteLine("Condition");
                                            textbookCreationDto.Condition = Console.ReadLine();

                                            Console.WriteLine("Edition");
                                            textbookCreationDto.Edition = Console.ReadLine();



                                            var data = textbookService.CreateAsync(textbookCreationDto);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Author} | {data.Result.Title} |  {data.Result.Price} | {data.Result.UserId} | {data.Result.SellerId} | {data.Result.Condition} | {data.Result.Edition}\n\n");



                                            break;
                                        }
                                    case 2:
                                        {


                                            Console.WriteLine("Id");
                                            textbookForUpdateDto.Id = long.Parse(Console.ReadLine());

                                            Console.WriteLine("Price");
                                            textbookForUpdateDto.Price = decimal.Parse(Console.ReadLine());

                                            Console.WriteLine("Title");
                                            textbookForUpdateDto.Title = Console.ReadLine();

                                            Console.WriteLine("Description");
                                            textbookForUpdateDto.Description = Console.ReadLine();

                                            var data = textbookService.UpdateAsync(textbookForUpdateDto);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Author} | {data.Result.Title} |  {data.Result.Price} | {data.Result.UserId} | {data.Result.SellerId} | {data.Result.Condition} | {data.Result.Edition}\n\n");

                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Id");
                                            long id = long.Parse(Console.ReadLine());
                                            Console.WriteLine(textbookService.RemoveAsync(id));
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Id");
                                            long id = long.Parse(Console.ReadLine());
                                            var data = textbookService.GetByIdAsync(id);
                                            Console.WriteLine($"{data.Result.Id} | {data.Result.Author} | {data.Result.Title} |  {data.Result.Price} | {data.Result.UserId} | {data.Result.SellerId} | {data.Result.Condition} | {data.Result.Edition}\n\n");

                                            break;
                                        }
                                    case 5:
                                        {
                                            var ls = textbookService.GetAllAsync();
                                            foreach (var data in ls.Result)
                                            {
                                                Console.WriteLine($"{data.Id} | {data.Author} | {data.Title} |  {data.Price} | {data.UserId} | {data.SellerId} | {data.Condition} | {data.Edition}\n\n");

                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            TextbookWindow = false; break;
                                        }
                                }
                            }
                            break;

                        }
                        
                }
                

            }
        }
    }
}

