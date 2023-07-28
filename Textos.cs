namespace EspacioTextos
{
    static class TextosJuego
    {
        public static string logo = @"
                                         _ __
        ___                             | '  \
   ___  \ /  ___         ,'\_           | .-. \        /|
   \ /  | |,'__ \  ,'\_  |   \          | | | |      ,' |_   /|
 _ | |  | |\/  \ \ |   \ | |\_|    _    | |_| |   _ '-. .-',' |_   _
// | |  | |____| | | |\_|| |__    //    |     | ,'_`. | | '-. .-',' `. ,'\_
\\_| |_,' .-, _  | | |   | |\ \  //    .| |\_/ | / \ || |   | | / |\  \|   \
 `-. .-'| |/ / | | | |   | | \ \//     |  |    | | | || |   | | | |_\ || |\_|
   | |  | || \_| | | |   /_\  \ /      | |`    | | | || |   | | | .---'| |
   | |  | |\___,_\ /_\ _      //       | |     | \_/ || |   | | | |  /\| |
   /_\  | |           //_____//       .||`      `._,' | |   | | \ `-' /| |
        /_\           `------'        \ |              `.\  | |  `._,' /_\
                                       \|       GAME         `.\
";
     public static string presentacion1 = @"╔════════════════════════════════════════════════╗
║                                                ║
║        ¡Bienvenida al Torneo de Hogwarts       ║
║           El Desafío de los Magos!             ║     
║                                                ║
╚════════════════════════════════════════════════╝";
public static string presentacion2 =
        @"╔═════════════════════════════════════════════════╗
║                                                 ║
║  En esta emocionante aventura, tendrás el honor ║
║  de convertirte en el encargado de dirigir el   ║
║  destino de 16 valientes personajes mágicos.    ║
║                                                 ║
╚═════════════════════════════════════════════════╝";
public static string presentacion3 =
        @"╔═════════════════════════════════════════════════╗
║                                                 ║
║  Deberás guiar a los 16 personajes a través de  ║
║  una serie de combates épicos, en los cuales    ║
║  deberán demostrar sus habilidades mágicas,     ║
║  astucia y valentía para avanzar en el torneo.  ║
║  Solo los más fuertes y habilidosos pasarán a   ║
║  las siguientes rondas: octavos de final,       ║
║  cuartos de final, semifinales y final.         ║
║                                                 ║
╚═════════════════════════════════════════════════╝";
public static string presentacion4 = @"╔═════════════════════════════════════════════════╗
║                                                 ║
║      ¡Podrás hacerlo aún más emocionante        ║
║      realizando apuestas junto a tus amigos!    ║
║        ¿Cuál es tu personaje favorito?          ║
║                                                 ║
╚═════════════════════════════════════════════════╝";
     public static string panelInicio1 =
@"╔══════════════════════════════════════════════╗
║                                              ║
║                _            _.,----,         ║
║     __  _.-._ / '-.        -  ,._  \)        ║
║    |  `-)_   '-.   \       / < _ )/"" }       ║
║    /__    '-.   \   '-, ___(c-(6)=(6)        ║
║     , `'.    `._ '.  _,'   >\    ""  )        ║
║     :;;,,'-._   '---' (  ( ""/`. -='/         ║
║    ;:;;:;;,  '..__    ,`-.`)'- '--'          ║
║     ;';:;;;;;'-._ /'._|   Y/   _/' \         ║
║           '''""._ F    |  _/ _.'._   `\       ║
║                  L    \   \/     '._  \      ║
║           .-,-,_ |     `.  `'---,  \_ _|     ║
║           //    'L    /  \,   (""--',=`)7     ║
║          | `._       : _,  \  /'`-._L,_'-._  ║
║          '--' '-.\__/ _L   .`'         './/  ║
║                      [ (  /                  ║
║                       ) `{                   ║
║                       \__)                   ║
║                                              ║
║          (1) Iniciar Torneo                  ║
║                                              ║
║          (2) Mostrar Personajes              ║  
║                                              ║
║          (3) Apuestas                        ║
║                                              ║
║          (4) Salir                           ║
║                                              ║
╚══════════════════════════════════════════════╝";
    public static string panelInicio2 =
@"╔══════════════════════════════════════════════╗
║                                              ║
║                _            _.,----,         ║
║     __  _.-._ / '-.        -  ,._  \)        ║
║    |  `-)_   '-.   \       / < _ )/"" }       ║
║    /__    '-.   \   '-, ___(c-(6)=(6)        ║
║     , `'.    `._ '.  _,'   >\    ""  )        ║
║     :;;,,'-._   '---' (  ( ""/`. -='/         ║
║    ;:;;:;;,  '..__    ,`-.`)'- '--'          ║
║     ;';:;;;;;'-._ /'._|   Y/   _/' \         ║
║           '''""._ F    |  _/ _.'._   `\       ║
║                  L    \   \/     '._  \      ║
║           .-,-,_ |     `.  `'---,  \_ _|     ║
║           //    'L    /  \,   (""--',=`)7     ║
║          | `._       : _,  \  /'`-._L,_'-._  ║
║          '--' '-.\__/ _L   .`'         './/  ║
║                      [ (  /                  ║
║                       ) `{                   ║
║                       \__)                   ║
║                                              ║
║          (1) Jugar de Nuevo                  ║
║                                              ║
║          (2) Ver Ganador                     ║  
║                                              ║
║          (3) Apuestas                        ║
║                                              ║
║          (4) Salir                           ║
║                                              ║
╚══════════════════════════════════════════════╝";
public static string OctavosDeFinal = "    "+@"
            _                             _         __ _             _ 
  ___   ___| |_ __ ___   _____  ___    __| | ___   / _(_)_ __   __ _| |
 / _ \ / __| __/ _` \ \ / / _ \/ __|  / _` |/ _ \ | |_| | '_ \ / _` | |
| (_) | (__| || (_| |\ V / (_) \__ \ | (_| |  __/ |  _| | | | | (_| | |
 \___/ \___|\__\__,_| \_/ \___/|___/  \__,_|\___| |_| |_|_| |_|\__,_|_|
";
public static string CuartosDFinal= "    "+@"
   ___                 _                  _         __ _             _ 
  / __\   _  __ _ _ __| |_ ___  ___    __| | ___   / _(_)_ __   __ _| |
 / / | | | |/ _` | '__| __/ _ \/ __|  / _` |/ _ \ | |_| | '_ \ / _` | |
/ /__| |_| | (_| | |  | || (_) \__ \ | (_| |  __/ |  _| | | | | (_| | |
\____/\__,_|\__,_|_|   \__\___/|___/  \__,_|\___| |_| |_|_| |_|\__,_|_|
";
public static string Semifinales = "    "+@"
 __                _  __ _             _ 
/ _\ ___ _ __ ___ (_)/ _(_)_ __   __ _| |
\ \ / _ \ '_ ` _ \| | |_| | '_ \ / _` | |
_\ \  __/ | | | | | |  _| | | | | (_| | |
\__/\___|_| |_| |_|_|_| |_|_| |_|\__,_|_|
";
 public static string Final = "    "+@"
  __ _             _ 
 / _(_)_ __   __ _| |
| |_| | '_ \ / _` | |
|  _| | | | | (_| | |
|_| |_|_| |_|\__,_|_|
";
 public static string Harry = @"
            _            _.,----,
 __  _.-._ / '-.        -  ,._  \) 
|  `-)_   '-.   \       / < _ )/"" }
/__    '-.   \   '-, ___(c-(6)=(6)
 , `'.    `._ '.  _,'   >\    ""  )
 :;;,,'-._   '---' (  ( ""/`. -='/ 
;:;;:;;,  '..__    ,`-.`)'- '--'
;';:;;;;;'-._ /'._|   Y/   _/' \
      '''""._ F    |  _/ _.'._   `\
             L    \   \/     '._  \
      .-,-,_ |     `.  `'---,  \_ _|
      //    'L    /  \,   (""--',=`)7
     | `._       : _,  \  /'`-._L,_'-._
     '--' '-.\__/ _L   .`'         './/
                 [ (  /
                  ) `{
       snd        \__)
";
public static string Ganador = @"
   ___                      _            
  / _ \__ _ _ __   __ _  __| | ___  _ __ 
 / /_\/ _` | '_ \ / _` |/ _` |/ _ \| '__|
/ /_\\ (_| | | | | (_| | (_| | (_) | |   
\____/\__,_|_| |_|\__,_|\__,_|\___/|_|   
";
    }
       
}