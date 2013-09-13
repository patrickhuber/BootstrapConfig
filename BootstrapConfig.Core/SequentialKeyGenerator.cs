using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class SequentialKeyGenerator : IKeyGenerator
    {
        /// <summary>
        /// The index
        /// </summary>
        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialKeyGenerator"/> class.
        /// </summary>
        public SequentialKeyGenerator() : this(0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SequentialKeyGenerator"/> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public SequentialKeyGenerator(int index)
        {
            this.index = index;
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            return (this.index++).ToString();
        }

        /// <summary>
        /// Rests this instance.
        /// </summary>
        public void Rest()
        {
            this.index = 0;
        }
    }
}
