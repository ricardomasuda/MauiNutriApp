using System.Collections.ObjectModel;
using System.Globalization;
using NutriApp.AppUtilities;
using NutriApp.Database;
using NutriApp.Models;

namespace NutriApp.Services;

 public static class FoodService
    {
        public static async Task<List<FoodModel>> GetListFoodModel(IEnumerable<MealFoodModel> listMealFoodModels)
        {
            List<FoodModel> listFoodModel = new();
            foreach (var mealFoodModel in listMealFoodModels)
            {
                FoodModel food = await ChangeUnitMeasure(mealFoodModel.FoodId, mealFoodModel.Medida);
                food.MealFoodId = mealFoodModel.Id;
                listFoodModel.Add(food);
            }

            return listFoodModel;
        }

        public static async Task<FoodModel> ChangeUnitMeasure(int foodId, double measure)
        {
            FoodModel food = RemoveNotApplicable(await new FoodDb().ConsultarAsync(foodId));
            food.Carboidratos = $"{CommonCalculations.Proportion(food.Carboidratos, measure)} {GetUnitMeasure(food.Carboidratos, NutrientsTypes.CARBOIDRATO)}";
            food.Proteinas = $"{CommonCalculations.Proportion(food.Proteinas, measure)} {GetUnitMeasure(food.Proteinas, NutrientsTypes.PROTEINA)}";
            food.Lipidios = $"{CommonCalculations.Proportion(food.Lipidios, measure)} {GetUnitMeasure(food.Lipidios, NutrientsTypes.LIPIDIO)}";
            food.Sodio = $"{CommonCalculations.Proportion(food.Sodio, measure)} {GetUnitMeasure(food.Sodio, NutrientsTypes.SODIO)}";
            food.FibraAlimentar = $"{CommonCalculations.Proportion(food.FibraAlimentar, measure)} {GetUnitMeasure(food.FibraAlimentar, NutrientsTypes.FIBRA_ALIMENTAR)}";
            food.ValorCalorico = $"{CommonCalculations.Proportion(food.ValorCalorico, measure)} {GetUnitMeasure(food.ValorCalorico, NutrientsTypes.VALOR_CALORICO)}";
            food.Medida = $"{measure}";
            return food;
        }
        
        public static ObservableCollection<FoodModel> AddUnitMeasureList(IEnumerable<FoodModel> listFood)
        {
            return new ObservableCollection<FoodModel>(listFood.Select(foodModel => AddUnitMeasureToValues(foodModel)).ToList());
        }

        public static FoodModel AddUnitMeasureToValues(FoodModel food)
        {
            food.Carboidratos = $"{food.Carboidratos}{GetUnitMeasure(food.Carboidratos, NutrientsTypes.CARBOIDRATO)}";
            food.Proteinas = $"{food.Proteinas}{GetUnitMeasure(food.Proteinas, NutrientsTypes.PROTEINA)}";
            food.Lipidios = $"{food.Lipidios}{GetUnitMeasure(food.Lipidios, NutrientsTypes.LIPIDIO)}";
            food.Sodio = $"{food.Sodio}{GetUnitMeasure(food.Sodio, NutrientsTypes.SODIO)}";
            food.FibraAlimentar = $"{food.FibraAlimentar}{GetUnitMeasure(food.FibraAlimentar, NutrientsTypes.FIBRA_ALIMENTAR)}";
            food.ValorCalorico = $"{food.ValorCalorico}{GetUnitMeasure(food.ValorCalorico, NutrientsTypes.VALOR_CALORICO)}";
            food.Medida = $"{food.Medida}{GetUnitMeasure(food.Medida, NutrientsTypes.MEDIDA)}";
            return food;
        }

        public static FoodModel RemoveUnitMeasurement(FoodModel food)
        {
            food.Carboidratos = Utils.RemoveUnityMeasure(food.Carboidratos,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.CARBOIDRATO));
            food.Proteinas = Utils.RemoveUnityMeasure(food.Proteinas,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.PROTEINA));
            food.Lipidios = Utils.RemoveUnityMeasure(food.Lipidios,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.LIPIDIO));
            food.Sodio = Utils.RemoveUnityMeasure(food.Sodio,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.SODIO));
            food.FibraAlimentar = Utils.RemoveUnityMeasure(food.FibraAlimentar,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.FIBRA_ALIMENTAR));
            food.ValorCalorico = Utils.RemoveUnityMeasure(food.ValorCalorico,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VALOR_CALORICO));
            food.Medida = Utils.RemoveUnityMeasure(food.Medida,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.MEDIDA));
            food.Calcio = Utils.RemoveUnityMeasure(food.Calcio,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.CALCIO));
            food.Magnesio = Utils.RemoveUnityMeasure(food.Magnesio,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.MAGNESIO));
            food.Manganes = Utils.RemoveUnityMeasure(food.Manganes,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.MANGANES));
            food.Ferro = Utils.RemoveUnityMeasure(food.Ferro,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.FERRO));
            food.Fosforo = Utils.RemoveUnityMeasure(food.Fosforo,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.FOSFORO));
            food.Potassio = Utils.RemoveUnityMeasure(food.Potassio,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.POTASSIO));
            food.Cobre = Utils.RemoveUnityMeasure(food.Cobre,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.COBRE));
            food.Zinco = Utils.RemoveUnityMeasure(food.Zinco,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.ZINCO));
            food.VitaminaA = Utils.RemoveUnityMeasure(food.VitaminaA,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_A));
            food.VitaminaB1 = Utils.RemoveUnityMeasure(food.VitaminaB1,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_B1));
            food.VitaminaB2 = Utils.RemoveUnityMeasure(food.VitaminaB2,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_B2));
            food.VitaminaB6 = Utils.RemoveUnityMeasure(food.VitaminaB6,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_B6));
            food.VitaminaB3 = Utils.RemoveUnityMeasure(food.VitaminaB3,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_B3));
            food.VitaminaC = Utils.RemoveUnityMeasure(food.VitaminaC,
                NutrientsBuild.AddUnitMeasure(NutrientsTypes.VITAMINA_C));
            return food;
        }

        public static FoodModel SumFoodNutrients(List<FoodModel> listFood)
        {
            var superFoodModel = new FoodDecimalModel();

            if (listFood.Count == 0) return ConvertFoodModel(superFoodModel);

            foreach (var foodModel in listFood)
            {
                RemoveUnitMeasurement(foodModel);
                superFoodModel.Carboidratos += CommonCalculations.ConverterDouble(foodModel.Carboidratos);
                superFoodModel.Proteinas += CommonCalculations.ConverterDouble(foodModel.Proteinas);
                superFoodModel.Lipidios += CommonCalculations.ConverterDouble(foodModel.Lipidios);
                superFoodModel.ValorCalorico += CommonCalculations.ConverterDouble(foodModel.ValorCalorico);
                superFoodModel.Medida += CommonCalculations.ConverterDouble(foodModel.Medida);
                superFoodModel.Sodio += CommonCalculations.ConverterDouble(foodModel.Sodio);
                superFoodModel.FibraAlimentar += CommonCalculations.ConverterDouble(foodModel.FibraAlimentar);
                superFoodModel.Calcio += CommonCalculations.ConverterDouble(foodModel.Calcio);
                superFoodModel.Magnesio += CommonCalculations.ConverterDouble(foodModel.Magnesio);
                superFoodModel.Manganes += CommonCalculations.ConverterDouble(foodModel.Manganes);
                superFoodModel.Ferro += CommonCalculations.ConverterDouble(foodModel.Ferro);
                superFoodModel.Fosforo += CommonCalculations.ConverterDouble(foodModel.Fosforo);
                superFoodModel.Potassio += CommonCalculations.ConverterDouble(foodModel.Potassio);
                superFoodModel.Cobre += CommonCalculations.ConverterDouble(foodModel.Cobre);
                superFoodModel.Zinco += CommonCalculations.ConverterDouble(foodModel.Zinco);
                superFoodModel.VitaminaA += CommonCalculations.ConverterDouble(foodModel.VitaminaA);
                superFoodModel.VitaminaB1 += CommonCalculations.ConverterDouble(foodModel.VitaminaB1);
                superFoodModel.VitaminaB2 += CommonCalculations.ConverterDouble(foodModel.VitaminaB2);
                superFoodModel.VitaminaB6 += CommonCalculations.ConverterDouble(foodModel.VitaminaB6);
                superFoodModel.VitaminaB3 += CommonCalculations.ConverterDouble(foodModel.VitaminaB3);
                superFoodModel.VitaminaC += CommonCalculations.ConverterDouble(foodModel.VitaminaC);
            }

            return ConvertFoodModel(superFoodModel);
        }
        
        public static FoodModel RoundMacro(FoodModel foodModel)
        {
            foodModel.Carboidratos = CommonCalculations.RoundNutrient(foodModel.Carboidratos, 2);
            foodModel.Proteinas = CommonCalculations.RoundNutrient(foodModel.Proteinas, 2);
            foodModel.Lipidios = CommonCalculations.RoundNutrient(foodModel.Lipidios, 2);
            foodModel.ValorCalorico = CommonCalculations.RoundNutrient(foodModel.ValorCalorico, 2);
            return foodModel;
        }
        
        private static string GetUnitMeasure(string valor, NutrientsTypes nutrientsTypes)
        {
            return CommonCalculations.IsDigit(valor) ? NutrientsBuild.AddUnitMeasure(nutrientsTypes) : "";
        }

        private static FoodModel ConvertFoodModel(FoodDecimalModel foodDecimalModel)
        {
            FoodModel foodModel = new ();

            foodModel.Id = foodDecimalModel.Id;
            foodModel.MealId = foodDecimalModel.MealId;
            foodModel.Nome = foodDecimalModel.Nome;
            foodModel.Quantidade = foodDecimalModel.Quantidade;
            foodModel.Carboidratos = foodDecimalModel.Carboidratos.ToString(CultureInfo.InvariantCulture);
            foodModel.Lipidios = foodDecimalModel.Lipidios.ToString(CultureInfo.InvariantCulture);
            foodModel.Medida = foodDecimalModel.Medida.ToString(CultureInfo.InvariantCulture);
            foodModel.Proteinas = foodDecimalModel.Proteinas.ToString(CultureInfo.InvariantCulture);
            foodModel.Sodio = foodDecimalModel.Sodio.ToString(CultureInfo.InvariantCulture);
            foodModel.FibraAlimentar = foodDecimalModel.FibraAlimentar.ToString(CultureInfo.InvariantCulture);
            foodModel.ValorCalorico = foodDecimalModel.ValorCalorico.ToString(CultureInfo.InvariantCulture);
            foodModel.Calcio = foodDecimalModel.Calcio.ToString(CultureInfo.InvariantCulture);
            foodModel.Magnesio = foodDecimalModel.Magnesio.ToString(CultureInfo.InvariantCulture);
            foodModel.Manganes = foodDecimalModel.Manganes.ToString(CultureInfo.InvariantCulture);
            foodModel.Ferro = foodDecimalModel.Ferro.ToString(CultureInfo.InvariantCulture);
            foodModel.Fosforo = foodDecimalModel.Fosforo.ToString(CultureInfo.InvariantCulture);
            foodModel.Potassio = foodDecimalModel.Potassio.ToString(CultureInfo.InvariantCulture);
            foodModel.Cobre = foodDecimalModel.Cobre.ToString(CultureInfo.InvariantCulture);
            foodModel.Zinco = foodDecimalModel.Zinco.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaA = foodDecimalModel.VitaminaA.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaB1 = foodDecimalModel.VitaminaB1.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaB2 = foodDecimalModel.VitaminaB2.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaB6 = foodDecimalModel.VitaminaB6.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaB3 = foodDecimalModel.VitaminaB3.ToString(CultureInfo.InvariantCulture);
            foodModel.VitaminaC = foodDecimalModel.VitaminaC.ToString(CultureInfo.InvariantCulture);

            return foodModel;
        }

        private static FoodModel RemoveNotApplicable(FoodModel foodModel)
        {
            foodModel.Nome = foodModel.Nome.Replace("-Não se aplica", "");
            return foodModel;
        }
    }