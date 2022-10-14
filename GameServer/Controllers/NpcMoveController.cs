using Communicate;
using Data.Interfaces;
using Data.Structures.Creature;
using Data.Structures.Geometry;
using Data.Structures.Npc;
using Data.Structures.World;
using GameServer.Networks.Packets.Response;
using System;
using Utility;

namespace GameServer.Controllers
{
    class NpcMoveController
    {
        public Creature Creature;

        public Npc Npc;

        //

        public bool IsActive = false;

        protected Point3D TargetPosition;

        protected int TargetDistance = 0;

        protected Point3D MoveVector;

        protected bool IsMove = false;

        protected bool IsNewDirection = false;

        public NpcMoveController(Creature creature)
        {
            Creature = creature;
            Npc = creature as Npc;

            TargetPosition = new Point3D();
            MoveVector = new Point3D();
        }

        public void Reset()
        {
            IsActive = false;
            IsMove = false;
        }

        public void Release()
        {
            Creature = null;
            Npc = null;
            TargetPosition = null;
        }

        public void MoveTo(WorldPosition position, int distance = 0)
        {
            position.CopyTo(TargetPosition);
            TargetDistance = distance;
            Move();
        }

        public void MoveTo(Point3D position, int distance = 0)
        {
            position.CopyTo(TargetPosition);
            TargetDistance = distance;
            Move();
        }

        public void MoveTo(float x, float y, int distance = 0)
        {
            TargetPosition.X = x;
            TargetPosition.Y = y;
            TargetDistance = distance;
            Move();
        }

        protected void Move()
        {
            IsNewDirection = true;
            IsActive = true;
        }

        public void Stop()
        {
            IsActive = false;
        }

        public void Action(long elapsed)
        {
            try
            {
                if (IsMove)
                {
                    Creature.Position.X += MoveVector.X;
                    Creature.Position.Y += MoveVector.Y;

                    IsMove = false;
                }

                if (!IsActive)
                    return;

                if (TargetDistance != 0)
                {
                    double d = TargetPosition.DistanceTo2D(Creature.Position) - 10;
                    double a = Geom.GetHeading(Creature.Position, Creature.Target.Position) * Math.PI / 32768;

                    TargetPosition.X = Creature.Position.X + (float)(Math.Cos(a) * d);
                    TargetPosition.Y = Creature.Position.Y + (float)(Math.Sin(a) * d);

                    TargetDistance = 0;
                }

                double distance = TargetPosition.DistanceTo2D(Creature.Position);

                if (distance < 10)
                {
                    TargetPosition.CopyTo(Creature.Position);
                    IsActive = false;
                    return;
                }

                int speed = GetSpeed();

                if (IsNewDirection)
                {
                    IsNewDirection = false;
                    Global.VisibleService.Send(Creature, new ResponseNpcMove(Creature, TargetPosition.X, TargetPosition.Y, TargetPosition.Z, (Creature.Target != null) ? 2 : 1));
                }

                double angle = Geom.GetHeading(Creature.Position) * Math.PI / 32768;

                MoveVector.X = (float)(Math.Cos(angle));
                MoveVector.Y = (float)(Math.Sin(angle));

                IsMove = true;
            }
            catch (Exception e)
            {
                Log.ErrorException("NpcMoveController.Action():", e);
            }
        }

        public void Resend(ISession session)
        {
            Global.VisibleService.Send(Creature, new ResponseNpcMove(Creature, TargetPosition.X, TargetPosition.Y, TargetPosition.Z, (Creature.Target != null) ? 2 : 1));
        }

        public int GetSpeed()
        {
            return 100;
        }
    }
}
