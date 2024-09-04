using Strategy;

var order = new Order(20, "Bachuki", "Tesla model 2 for Geeks");
order.Export(new CsvExportService());
order.Export(new JsonExportService());

