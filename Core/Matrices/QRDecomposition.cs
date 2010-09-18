﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.Numerics.Matrices {

    /// <summary>
    /// Represents a QR decomposition of a matrix.
    /// </summary>
    public sealed class QRDecomposition {

        private double[] qtStore;
        private double[] rStore;
        private int rows, columns;

        internal QRDecomposition (double[] qtStore, double[] rStore, int rows, int columns) {
            this.qtStore = qtStore;
            this.rStore = rStore;
            this.rows = rows;
            this.columns = columns;
        }

        /// <summary>
        /// The orthogonal matrix Q.
        /// </summary>
        /// <returns>The orthogonal matrix Q.</returns>
        public SquareMatrix QMatrix () {
            double[] qStore = new double[rows * rows];
            for (int r = 0; r < rows; r++) {
                for (int c = 0; c < rows; c++) {
                    qStore[rows * c + r] = qtStore[rows * r + c];
                }
            }
            return (new SquareMatrix(qStore, rows));
        }

        /// <summary>
        /// The upper-right triangular matrix R.
        /// </summary>
        /// <returns>The upper-right triangular matrix R.</returns>
        public Matrix RMatrix () {
            double[] store = new double[rows * columns];
            Array.Copy(rStore, store, rStore.Length);
            return (new Matrix(store, rows, columns));
        }

        /*
        public ColumnVector Solve (IList<double> rhs) {

            if (rhs == null) throw new ArgumentNullException("rhs");
            if (rhs.Count != rows) throw new DimensionMismatchException();

            double[] y = new double[rhs.Count];
            rhs.CopyTo(y, 0);

            y = MatrixAlgorithms.Multiply(qtStore, rows, rows, y, rows, 1);

            return (new ColumnVector(y));
        }
        */

        /// <summary>
        /// Get the number of rows in the original matrix.
        /// </summary>
        public int RowCount {
            get {
                return (rows);
            }
        }

        /// <summary>
        /// Gets the number of columns in the original matrix.
        /// </summary>
        public int ColumnCount {
            get {
                return (columns);
            }
        }

    }

}
