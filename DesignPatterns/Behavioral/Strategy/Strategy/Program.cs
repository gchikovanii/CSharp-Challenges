using Strategy;

var order = new Order(20, "Bachuki", "Tesla model 2 for Geeks");
order.ExportService = new CsvExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();

