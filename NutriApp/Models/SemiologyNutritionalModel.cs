using System.Collections.ObjectModel;

namespace NutriApp.Models;

 public class SemiologyNutritionalModel
{
    public string Regiao { get; set; }
    public string Manifestacao { get; set; }
    public string Significados { get; set; }

    public ObservableCollection<SemiologyNutritionalModel> LoadList()
    {
        return new ObservableCollection<SemiologyNutritionalModel>
        {
            new() {Regiao = "Fáceis" , Manifestacao = "Paciente cansado, não consegue ficar com olhos abertos por muito tempo", Significados = "Desnutrição aguda"},
            new() {Regiao = "Fáceis I" , Manifestacao = "Aparência de tristeza, depressão", Significados = "Desnutrição crônica"},
            new() {Regiao = "Face" , Manifestacao = "Edema abaixo dos olhos / edema periorbita" , Significados = "Desnutrição energético proteico e falta de Ferro"},
            new() {Regiao = "Face I" , Manifestacao = "Edema Lua cheia / arredondada" , Significados = "Desnutrição energético - proteico e falta de Ferro"},
            new() {Regiao = "Têmporas" , Manifestacao = "Atrofia bitemporal " , Significados = "Ingestão insuficiente, imunoincompetência"},
            new() {Regiao = "Bola gordurosa de Bichart" , Manifestacao = "Depletada. Associa-se com a atrofia temporal, formando o sinal de “asa quebrada”" , Significados = "Perda proteico-calórica prolongada"},
            new() {Regiao = "Olhos" , Manifestacao = "Brilho reduzido, tendem a ficar encovados" , Significados = "Desidratação"},
            new() {Regiao = "Olhos I" , Manifestacao = "Amarelados /  icterícia" , Significados = "Acúmulo de bilirrubina"},
            new() {Regiao = "Olhos II" , Manifestacao = "Xantelasma /  acúmulo de gordura abaixo dos olhos" , Significados = "Hiperlipidemia"},
            new() {Regiao = "Olhos III" , Manifestacao = "Excessivamente secos / xerose" , Significados = "Falta de vitamina A ou consequência de medicamentos"},
            new() {Regiao = "Olhos IV" , Manifestacao = "Cegueira noturna / manchas brancas nos olhos / Manchas de Bitot" , Significados = "Falta de vitamina A"},
            new() {Regiao = "Olhos V" , Manifestacao = "Palidez conjuntival, xerose, blefarite angular" , Significados = "Ferro, vitamina A, B2 e B6"},
        };
    }
}