using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delta.WPF.Controls.Base;

namespace Delta.WPF.Controls.Diffing
{
    public class DiffEngine
    {
        public List<DiffOperation> CalculateDiff(VisualNode oldTree, VisualNode newTree)
        {
            return oldTree.Diff (newTree);
        }
    }
}
