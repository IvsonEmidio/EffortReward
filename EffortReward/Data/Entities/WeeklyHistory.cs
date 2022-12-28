namespace EffortReward.Data.Entities
{
    public class WeeklyHistory
    {
        public enum StrategyEnum
        {
            SEM_JEJUM_SEM_EXERCICIOS,
            CORRIDA_LOWCARB_JEJUM_MUSCULACAO,
            CORRIDA_E_JEJUM,
            APENAS_CORRIDA,
            APENAS_MUSCULACAO,
            JEJUM_DIARIO_18_HRS,
            JEJUJM_INTERCALADO_24_HRS
        };

        public enum ResultEnum
        {
            SUCCESS,
            FAIL,
        }

        public enum ConsumeEnum
        {
            LOW,
            MEDIUM,
            HIGH,
        }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int WeekNum { get; set; }
        public StrategyEnum Strategy { get; set; }
        public ResultEnum Result { get; set; }
        public double Weight { get; set; }
        public ConsumeEnum Sugar { get; set; }
        public ConsumeEnum Junk { get; set; }
        public ConsumeEnum FoodQuality { get; set; }
        public int QntJJ { get; set; }
        public int QntMM { get; set; }
        public double Variation { get; set; }
    }
}
