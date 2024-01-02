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
            Document
            .Create(container =>
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

                        //column.Item().Table(c =>
                        //{
                        //  // row.Spacing(20);

                        //        c.Cell().Text(Placeholders.LoremIpsum());

                        //        // Add a table
                        //        c.Cell().Table(table =>
                        //        {
                        //            // Add columns to the table
                        //            table.Cell().Element(CellStyle).t;
                        //            table.Cell().Element(CellStyle);

                        //            // Add rows to the table
                        //            table.AddRow("Row 1, Cell 1", "Row 1, Cell 2");
                        //            table.AddRow("Row 2, Cell 1", "Row 2, Cell 2");
                        //            // Add more rows as needed
                        //        });
                        //        c.Item().Text(Placeholders.LoremIpsum());
                        //        c.Item().Image(Placeholders.Image(200, 100));
                        //       // c.Item().Image(Placeholders.Image(200, 100));
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
                                      //grid.Item().Height(50).Image("C:\\Users\\PC 2\\source\repos\\CreatePdf");
                              });
                        });


                        //column.Item().Row(row =>
                        //{
                        //    row.RelativeColumn().Table(table =>
                        //    {
                        //        table.Cell().Row(1).Column(4).Element(Block).Text("A");
                        //        table.Cell().Row(2).Column(2).Element(Block).Text("B");
                        //        table.Cell().Row(3).Column(3).Element(Block).Text("C");
                        //        table.Cell().Row(4).Column(1).Element(Block).Text("D");

                        //        table.AddRow().Text(row =>
                        //        {
                        //            row.Cell("Row 1, Cell 1");
                        //            row.Cell("Row 1, Cell 2");
                        //        });

                        //        table.AddRow(row =>
                        //        {
                        //            row.Cell("Row 2, Cell 1");
                        //            row.Cell("Row 2, Cell 2");
                        //        });
                        //    });
                        //});

                        column.Item().Text(text =>
                         {
                             text.Span("This is a normal text, followed by some ");
                             text.Span("underlined text.").Underline();
                         });

                    });

                    

                    //page.Content().Table(table =>
                    //{
                    //    // step 1
                    //    table.ColumnsDefinition(columns =>
                    //    {
                    //        columns.ConstantColumn(25);
                    //        columns.RelativeColumn(3);
                    //        columns.RelativeColumn();
                    //        columns.RelativeColumn();
                    //        columns.RelativeColumn();
                    //    });

                    //    // step 2
                    //    table.Header(header =>
                    //    {
                    //        header.Cell().Element(CellStyle).Text("#");
                    //        header.Cell().Element(CellStyle).Text("Product");
                    //        header.Cell().Element(CellStyle).AlignRight().Text("Unit price");
                    //        header.Cell().Element(CellStyle).AlignRight().Text("Quantity");
                    //        header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    //        static IContainer CellStyle(IContainer container)
                    //        {
                    //            return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    //        }
                    //    });
                    //});


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
            .GeneratePdf("hello.pdf");
            //.ShowInPreviewer();

            //Document.Create(container =>
            //{
            //    container.Page(page =>
            //    {

            //    });
            //}).ShowInPreviewer();
            //Console.WriteLine("Hello World!!!!");
        }
    }
}
