using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorDemo
{
    class CompositePainter<TPainter> : IPainter where TPainter : IPainter
    {
        public bool IsAvailable => _Painters.Any(painter => painter.IsAvailable);
        private IEnumerable<TPainter> _Painters { get; }
        private Func<double, IEnumerable<TPainter>, IPainter> _Reduce { get; }


        public CompositePainter(IEnumerable<TPainter> painters,
            Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            _Painters = painters.ToList();
            _Reduce = reduce;
        }

        
            
        

        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _Reduce(sqMeters, _Painters).EstimateTimeToPaint(sqMeters);


        public double EstimateCompensation(double sqMeters) =>
            _Reduce(sqMeters, _Painters).EstimateCompensation(sqMeters);    
        
    }
}
