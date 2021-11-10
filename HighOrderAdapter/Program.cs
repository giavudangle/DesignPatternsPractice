using System;
using System.Threading;



namespace Adapter
{
    enum VECTOR_STATE
    {
        INITIALIZED,
        PROJECTED_TO_OXY,
        PROJECTED_TO_ALPHABET,
        CHANGED_DIRECTION
    }
    interface IVector
    {
        VECTOR_STATE State { get; set; }
    }
    interface IOxyProjection
    {
        void projectedToOxy(IVector vector);
    }

    interface IAlphabetProjection
    {
        void projectedToAlphabet(IVector vector);
    }
    interface IChangeDirection
    {
        void changedVectorDirection(IVector vector);
    }

    class Vector : IVector
    {
        public VECTOR_STATE State { get; set; }

        public Vector()
        {
            State = VECTOR_STATE.INITIALIZED;
        }

    }

    class OxyProjection : IOxyProjection
    {
        public void projectedToOxy(IVector vector)
        {
            Console.WriteLine("Projecting to Oxy");
            Thread.Sleep(500);
            vector.State = VECTOR_STATE.PROJECTED_TO_OXY;
            Console.WriteLine($"Vector current state {vector.State}");

        }
    }

    class AlphabetProjection : IAlphabetProjection
    {

        public void projectedToAlphabet(IVector vector)
        {
            Console.WriteLine("Projecting to Alphabet");
            Thread.Sleep(500);
            vector.State = VECTOR_STATE.PROJECTED_TO_ALPHABET;
            Console.WriteLine($"Vector current state {vector.State}");
        }
    }

    class ChangeVectorDirection : IChangeDirection
    {

        public void changedVectorDirection(IVector vector)
        {
            Console.WriteLine("Changing vector Direction");
            Thread.Sleep(500);
            vector.State = VECTOR_STATE.CHANGED_DIRECTION;
            Console.WriteLine($"Vector current state {vector.State}");
        }

    }

    class ConvertVectorToOxyProjectionAdapter : IOxyProjection
    {
        private readonly IVector _vector;
        private readonly OxyProjection _oxyProjection;

        public ConvertVectorToOxyProjectionAdapter(IVector vector)
        {
            _vector = vector;
            _oxyProjection = new OxyProjection();
        }

        public void projectedToOxy(IVector vector)
        {
            _oxyProjection.projectedToOxy(_vector);
        }
    }

    class ConvertVectorToAlphabetProjectionAdapter : IAlphabetProjection
    {
        private readonly IVector _vector;
        private readonly IAlphabetProjection _alphabetProjection;

        public ConvertVectorToAlphabetProjectionAdapter(IVector vector)
        {
            _vector = vector;
            _alphabetProjection = new AlphabetProjection();
        }


        public void projectedToAlphabet(IVector vector)
        {
            _alphabetProjection.projectedToAlphabet(_vector);
        }
    }

    class ConvertVectorToChangeDirection : IChangeDirection
    {
        private readonly IChangeDirection _direction;
        private readonly IVector _vector;


        public ConvertVectorToChangeDirection(IVector vector)
        {
            _vector = vector;
            _direction = new ChangeVectorDirection();
        }


        public void changedVectorDirection(IVector vector)
        {
            _direction.changedVectorDirection(_vector);
        }
    }



    internal class Program
    {
        static void VectorToOxyProjectionAdapter(IVector vector)
        {
            ConvertVectorToOxyProjectionAdapter adapter = new ConvertVectorToOxyProjectionAdapter(vector);
            adapter.projectedToOxy(vector);
        }
        static void VectorToAlphabetProjectionAdapter(IVector vector)
        {
            ConvertVectorToAlphabetProjectionAdapter adapter = new ConvertVectorToAlphabetProjectionAdapter(vector);
            adapter.projectedToAlphabet(vector);
        }
        static void VectorToChangeDirectionAdapter(IVector vector)
        {
            ConvertVectorToChangeDirection adapter = new ConvertVectorToChangeDirection(vector);
            adapter.changedVectorDirection(vector);
        }
        static void Main(string[] args)
        {
            // Từ vector ban đầu ta cần chuyển đổi thành 3 dạng :
            // 1. Chiếu vector Oxy
            // 2. Chiếu vector lên bảng alphabet
            // 3. Đổi chiều vector
            // => Phải xây dựng ra 3 adapter để chuyển

            IVector vector = new Vector();
            Console.WriteLine($"Current Vector State : {vector.State}");
            VectorToOxyProjectionAdapter(vector);
            VectorToAlphabetProjectionAdapter(vector);
            VectorToChangeDirectionAdapter(vector);


        }
    }
}