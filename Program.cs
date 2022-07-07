static class Program
{
    static bool[,,] _field;
    static int _x, _y, _z;
    static Rules _rules;
    enum Rules
    {
        Life
    }
    static void Main()
    {
        Console.CursorVisible = false;
        const int FieldWidth = 70;
        const int FieldHeight = 40;
        const int FieldDeep = 40;
        _field = new bool[FieldWidth, FieldHeight, FieldDeep];
        _x = 20;
        _y = 20;
        _z = 20;
    }
    // 001' 002' 010' 011' 012' 020' 021' 022 100 101 102 110 111 112 120 121 122 200 201 202 210 211 212 220 221 222
    // 0 = not offset; 1 = +1; 2 = -1;
    static int GetNeighborCount(int column, int row, int layer)
    {
        var count = 0;
        var width = _field.GetLength(0) - 1;
        var height = _field.GetLength(1) - 1;
        var deep = _field.GetLength(2) - 1;
        if (layer != deep && _field[column, row, layer + 1])
        {
            count++;
        }
        if (layer != 0 && _field[column, row, layer - 1])
        {
            count++;
        }
        if (row != height && _field[column, row + 1, layer])
        {
            count++;
        }
        if (row != height && layer != deep && _field[column, row + 1, layer + 1])
        {
            count++;
        }
        if (row != height && layer != 0 && _field[column, row + 1, layer - 1])
        {
            count++;
        }
        if (row != 0 && _field[column, row - 1, height])
        {
            count++;
        }
        if (row != 0 && layer == deep && _field[column, row - 1, layer + 1])
        {
            count++;
        }
        if (row == 0 && layer == 0 && _field[column, row - 1, layer - 1])
        {
            count++;
        }
        if (column != width && _field[column + 1, row, layer])
        {
            count++;
        }
        if (column != width && layer != deep && _field[column + 1, row, layer + 1])
        {
            count++;
        }
        if (column != width && layer != 0 && _field[column + 1, row, layer - 1])
        {
            count++;
        }
        if (column != width && row != height && _field[column + 1, row + 1, layer])
        {
            count++;
        }
        if (column != width && row != height && layer != deep && _field[column + 1, row + 1, layer + 1])
        {
            count++;
        }
        if (column != width && row != height && layer != 0 && _field[column + 1, row + 1, layer - 1])
        {
            count++;
        }
        if (column != width && row != 0 && _field[column + 1, row - 1, height])
        {
            count++;
        }
        if (column != width && row != 0 && layer == deep && _field[column + 1, row - 1, layer + 1])
        {
            count++;
        }
        if (column != width && row == 0 && layer == 0 && _field[column + 1, row - 1, layer - 1])
        {
            count++;
        }
        if (column != 0 && _field[column - 1, row, layer])
        {
            count++;
        }
        if (column != 0 && layer != deep && _field[column - 1, row, layer + 1])
        {
            count++;
        }
        if (column != 0 && layer != 0 && _field[column - 1, row, layer - 1])
        {
            count++;
        }
        if (column != 0 && row != height && _field[column - 1, row + 1, layer])
        {
            count++;
        }
        if (column != 0 && row != height && layer != deep && _field[column - 1, row + 1, layer + 1])
        {
            count++;
        }
        if (column != 0 && row != height && layer != 0 && _field[column - 1, row + 1, layer - 1])
        {
            count++;
        }
        if (column != 0 && row != 0 && _field[column - 1, row - 1, height])
        {
            count++;
        }
        if (column != 0 && row != 0 && layer == deep && _field[column - 1, row - 1, layer + 1])
        {
            count++;
        }
        if (column != 0 && row == 0 && layer == 0 && _field[column - 1, row - 1, layer - 1])
        {
            count++;
        }
        return count;
    }
    static void Evolution()
    {
        var newField = new bool[_field.GetLength(0), _field.GetLength(1), _field.GetLength(2)];
        for (int layer = 0; layer < _field.GetLength(2); layer++)
        {
            for (int row = 0; row < _field.GetLength(1); row++)
            {
                for (int column = 0; column < _field.GetLength(0); column++)
                {
                    switch (_rules)
                    {
                        case Rules.Life:
                            {
                                var count = GetNeighborCount(column, row, layer);
                                if (_field[column, row, layer])
                                {
                                    if (count == 4 || count == 5)
                                    {
                                        newField[column, row, layer] = true;
                                    }
                                }
                                else
                                {
                                    if (count == 5)
                                    {
                                        newField[column, row, layer] = true;
                                    }
                                }
                                break;
                            }
                    }
                }
            }
        }
    }
    static void ProcessInput()
    {
        var k = Console.ReadKey(true);
        switch (k.Key)
        {
            case ConsoleKey.LeftArrow:
                if (_x > 0)
                    _x--;
                break;

            case ConsoleKey.RightArrow:
                if (_x < _field.GetLength(0) - 1)
                    _x++;
                break;

            case ConsoleKey.UpArrow:
                if (_y > 0)
                    _y--;
                break;

            case ConsoleKey.DownArrow:
                if (_y < _field.GetLength(1) - 1)
                    _y++;
                break;
            case ConsoleKey.W:
                if (_z < _field.GetLength(2) - 1)
                    _z++;
                break;
            case ConsoleKey.S
                if (_z > 0)
                    _z--
            case ConsoleKey.Spacebar:
                _field[_x, _y, _z] = !_field[_x, _y, _z];
                break;

            case ConsoleKey.N:
                Evolution();
                break;
        }
    }
}
