using System;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace CreatePdf
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, QuestPDF.Infrastructure.Unit.Centimetre);
                    page.Background(Colors.White);
                    //page.DefaultTextStyle(x => x.FontSize(35));


                    page.Header()
                        .Text("Hello PDF!")
                        .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                    //page.Content()
                    //    .PaddingVertical(1, Unit.Centimetre)
                    //    .Column(x =>
                    //    {
                    //        x.Spacing(20);
                    //        x.Item().Text(Placeholders.LoremIpsum());
                    //        x.Item().Image(Placeholders.Image(200, 100));
                    //    });
                    page.Content().Column(column =>
                    {
                        column.Spacing(20);
                        column.Item().Text(Placeholders.LoremIpsum());
                        column.Item().Image(Placeholders.Image(200, 100));

                        column.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });
                        });

                        column.Item().Row(row =>
                        {
                            row.Spacing(20);
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200, 100));
                            });

                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text(Placeholders.LoremIpsum());
                                c.Item().Image(Placeholders.Image(200,100));
                            });

                        });

                        column.Item().Row(row =>
                        {
                               row.RelativeItem().Grid(grid =>
                               {
                                    grid.VerticalSpacing(15);
                                    grid.HorizontalSpacing(15);
                                    grid.AlignCenter();
                                    grid.Columns(10); // 12 by default

                                    grid.Item(6).Background(Colors.Blue.Lighten1).Height(50);
                                    grid.Item(4).Background(Colors.Blue.Lighten3).Height(50);

                                    grid.Item(2).Background(Colors.Teal.Lighten1).Height(70);
                                    grid.Item(3).Background(Colors.Teal.Lighten2).Height(70);
                                    grid.Item(5).Background(Colors.Teal.Lighten3).Height(70);

                                    grid.Item(2).Background(Colors.Green.Lighten1).Height(50);
                                    grid.Item(2).Background(Colors.Green.Lighten2).Height(50);
                                    grid.Item(2).Background(Colors.Green.Lighten3).Height(50);
                               });
                        });
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(column =>
                            {
                                foreach (var i in Enumerable.Range(1, 8))
                                {
                                    column.Item().Row(row =>
                                    {
                                        row.Spacing(5);
                                        row.AutoItem().Text($"{i}."); // text or image
                                        row.RelativeItem().Text(Placeholders.Sentence());
                                    });
                                }
                            });
                        });
                        column.Item().Row(row =>
                        {
                            row.RelativeColumn().Grid(grid =>
                              {
                                  grid.Columns(3);
                                  grid.Spacing(5);
 
                                  foreach (var _ in Enumerable.Range(0, 8))
                                      grid.Item().Height(50).Placeholder("Text");
                                     
                             });
                        });

                        column.Item().Text(text =>
                         {
                             text.Span("This is a normal text, followed by some ");
                             text.Span("underlined text.").Underline();
                         });

                    });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                                //x.Span("Page ");
                            x.CurrentPageNumber();
                            x.Span(" / ");
                            x.TotalPages();
                        });


                });
            })
            //.GeneratePdf("hello.pdf");
            .ShowInPreviewer();
        }
    }
}
