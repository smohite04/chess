using Chess.Application;
using Chess.Domain;
using CommonServiceLocator;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Host
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<IServiceLocator>().Use<StructureMapServiceLocator>();
            For<IUseCase<string, string>>().Use<EmptyBoardPieceMovementUseCase>().Named(Keystore.EmptyChessMovement);
            For<IDirection>().Use<Direction>();
            For<IOptionhandler>().Use<EmptyChessOptionhandler>().Named(Keystore.EmptyChessMovement);
            For<IOptionhandler>().Use<ExitHandler>().Named(Keystore.Exit);
        }
    }
}
