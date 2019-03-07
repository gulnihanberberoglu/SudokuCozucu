using System;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YazLabSudokuCozucu
{
    public class SudokuCozucu
    {
        //2 boyutlu sudoku ve get set metotları tanımlanıyor 
        public int[,] Sudoku { get; private set; }

        //Thread
        Action<int, int, int, CancellationToken> sudokuDegisti;

        CancellationToken token;

        //SudokuCozucu constructor'ı
        public SudokuCozucu(int[,] sudoku, Action<int, int, int, CancellationToken> action, CancellationToken token)
        {
            Sudoku = sudoku;
            sudokuDegisti = action;
            this.token = token;
        }

        //yatay konum algoritmasına göre çözer
        public bool Coz1(int row, int col)
        {
            if (row < 9 && col < 9)
            {
                if (Sudoku[row, col] != 0)
                {
                    if ((col + 1) < 9)
                        return Coz1(row, col + 1);
                    else if ((row + 1) < 9)
                        return Coz1(row + 1, 0);
                    else
                        return true;
                }
                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (DegerUygunMu(row, col, i + 1))
                        {
                            Sudoku[row, col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (Coz1(row, col + 1)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (Coz1(row + 1, 0)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }

                return false;
            }
            else return true;
        }

        //dikey konum algoritmasına göre çözer
        public bool Coz2(int row, int col)
        {
            if (row < 9 && col < 9)
            {
                if (Sudoku[row, col] != 0)
                {
                    if ((row + 1) < 9)
                        return Coz2(row + 1, col);
                    else if ((col + 1) < 9)
                        return Coz2(0, col + 1);
                    else
                        return true;
                }
                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (DegerUygunMu(row, col, i + 1))
                        {
                            Sudoku[row, col] = i + 1;

                            if ((row + 1) < 9)
                            {
                                if (Coz2(row + 1, col)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else if ((col + 1) < 9)
                            {
                                if (Coz2(0, col + 1)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }

                return false;
            }
            else return true;
        }

        //yatay konum algoritmasına göre çözer 
        public bool Coz3(int row, int col)
        {
            if (row < 9 && col < 9)
            {
                if (Sudoku[row, col] != 0)
                {
                    if ((col + 1) < 9)
                        return Coz3(row, col + 1);
                    else if ((row + 1) < 9)
                        return Coz3(row + 1, 0);
                    else
                        return true;
                }
                else
                {
                    for (int i = 0; i < 9; ++i)
                    {
                        if (DegerUygunMu(row, col, i + 1))
                        {
                            Sudoku[row, col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (Coz3(row, col + 1)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (Coz3(row + 1, 0)) return true;
                                else Sudoku[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }

                return false;
            }
            else return true;
        }

        //sudoku da yazılacak değerin kontrolü
        private bool DegerUygunMu(int row, int col, int num)
        {
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                if (Sudoku[row, i] == num)
                {
                    return false;
                }

                if (Sudoku[i, col] == num)
                {
                    return false;
                }

                if (Sudoku[rowStart + (i % 3), colStart + (i / 3)] == num)
                {
                    return false;
                }
            }

            //hangi sudoku değişicekse o değişikliği ekrana yazan  metodunu çalıştırıyor
            sudokuDegisti(row, col, num, token); 
            return true;
        }
    }
}

