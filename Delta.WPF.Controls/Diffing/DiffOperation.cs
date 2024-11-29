using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delta.WPF.Controls.Base;

namespace Delta.WPF.Controls.Diffing
{
    public class DiffOperation
    {
        public DiffOperationType Type { get; set; }
        public VisualNode? OldNode { get; set; }
        public VisualNode? NewNode { get; set; }
        public VisualNode? TargetNode { get; set; }
        public string? PropertyKey { get; set; }
        public object? NewValue { get; set; }
    }
