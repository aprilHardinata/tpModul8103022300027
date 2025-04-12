// See https://aka.ms/new-console-template for more information
using System.Text.Json;

CovidConfig config;

if (File.Exists("covid_config.json"))
{
    string json = File.ReadAllText("covid_config.json");
    config = JsonSerializer.Deserialize<CovidConfig>(json);
}
else
{
    config = new CovidConfig(); // default value
}

Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}:");
double suhu = double.Parse(Console.ReadLine());

Console.WriteLine("Berapa hari yang lalu (terakhir) anda memiliki gejala demam?");
int hari = int.Parse(Console.ReadLine());

Console.WriteLine("Apakah Anda ingin mengubah satuan suhu? (y/n)");
string jawaban = Console.ReadLine().ToLower();

if (jawaban == "y")
{
    config.UbahSatuan();
    Console.WriteLine("Satuan suhu telah diubah menjadi " + config.satuan_suhu);
}

Console.WriteLine("Satuan suhu telah diubah menjadi " + config.satuan_suhu);

if (suhu < config.batas_demam && hari < config.batas_demam)
{
    Console.WriteLine(config.pesan_diterima);
}
else
{
    Console.WriteLine(config.pesan_ditolak);
}

