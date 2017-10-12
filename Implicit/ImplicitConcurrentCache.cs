using System;
using System.Threading;

namespace TinkerWorX.AccidentalNoiseLibrary
{
    public sealed class ImplicitConcurrentCache : ImplicitModuleBase
    {
        private readonly ThreadLocal<Cache> cache2D = new ThreadLocal<Cache>(() => new Cache());

        private readonly ThreadLocal<Cache> cache3D = new ThreadLocal<Cache>(() => new Cache());

        private readonly ThreadLocal<Cache> cache4D = new ThreadLocal<Cache>(() => new Cache());

        private readonly ThreadLocal<Cache> cache6D = new ThreadLocal<Cache>(() => new Cache());

        public ImplicitConcurrentCache(ImplicitModuleBase source)
        {
            this.Source = source;
        }

        public ImplicitModuleBase Source { get; set; }

        public override Double Get(Double x, Double y)
        {
            if (!this.cache2D.Value.IsValid || this.cache2D.Value.X != x || this.cache2D.Value.Y != y)
            {
                this.cache2D.Value.X = x;
                this.cache2D.Value.Y = y;
                this.cache2D.Value.IsValid = true;
                this.cache2D.Value.Value = this.Source.Get(x, y);
            }
            return this.cache2D.Value.Value;
        }

        public override Double Get(Double x, Double y, Double z)
        {
            if (!this.cache3D.Value.IsValid || this.cache3D.Value.X != x || this.cache3D.Value.Y != y || this.cache3D.Value.Z != z)
            {
                this.cache3D.Value.X = x;
                this.cache3D.Value.Y = y;
                this.cache3D.Value.Z = z;
                this.cache3D.Value.IsValid = true;
                this.cache3D.Value.Value = this.Source.Get(x, y, z);
            }
            return this.cache3D.Value.Value;
        }

        public override Double Get(Double x, Double y, Double z, Double w)
        {
            if (!this.cache4D.Value.IsValid || this.cache4D.Value.X != x || this.cache4D.Value.Y != y || this.cache4D.Value.Z != z || this.cache4D.Value.W != w)
            {
                this.cache4D.Value.X = x;
                this.cache4D.Value.Y = y;
                this.cache4D.Value.Z = z;
                this.cache4D.Value.W = w;
                this.cache4D.Value.IsValid = true;
                this.cache4D.Value.Value = this.Source.Get(x, y, z, w);
            }
            return this.cache4D.Value.Value;
        }

        public override Double Get(Double x, Double y, Double z, Double w, Double u, Double v)
        {
            if (!this.cache6D.Value.IsValid || this.cache6D.Value.X != x || this.cache6D.Value.Y != y || this.cache6D.Value.Z != z || this.cache6D.Value.W != w || this.cache6D.Value.U != u || this.cache6D.Value.V != v)
            {
                this.cache6D.Value.X = x;
                this.cache6D.Value.Y = y;
                this.cache6D.Value.Z = z;
                this.cache6D.Value.W = w;
                this.cache6D.Value.U = u;
                this.cache6D.Value.V = v;
                this.cache6D.Value.IsValid = true;
                this.cache6D.Value.Value = this.Source.Get(x, y, z, w, u, v);
            }
            return this.cache6D.Value.Value;
        }
    }
}