using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class Painters
    {
        private IEnumerable<IPainter> _ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            _ContainedPainters = painters.ToList();
        }

        public Painters GetAvailable() =>
            new Painters(_ContainedPainters.Where(painter => painter.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters) =>
            _ContainedPainters.WithMinimun(painter => painter.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            _ContainedPainters.WithMinimun(painter => painter.EstimateTimeToPaint(sqMeters));

    }
}
