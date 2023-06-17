namespace Ruch_Browna.Models
{
    public class BrownianMotionIndex
    {
        public ParticlePositionGenerator ParticlePositionGenerator { get; set; }

        public BrownianMotionIndex()
        {
            ParticlePositionGenerator = new ParticlePositionGenerator();
        }
    }
}
