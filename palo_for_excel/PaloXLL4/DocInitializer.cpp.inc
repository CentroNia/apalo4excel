
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloInit";
        fd.c_name = "palo_init";
        fd.short_desc["en"] = L"Connects to a PALO server.";
        fd.short_desc["de-DE"] = L"Verbindet mit einem PALO Server.";
        fd.short_desc["fr-FR"] = L"Se connecte avec un serveur Palo.";
        fd.short_desc["cs-CZ"] = L"Connects to a PALO server.";
        fd.long_desc["en"] = L"Connects to a PALO server.";
        fd.long_desc["de-DE"] = L"Verbindet mit einem PALO Server.";
        fd.long_desc["fr-FR"] = L"Se connecte avec un serveur Palo.";
        fd.long_desc["cs-CZ"] = L"Connects to a PALO server.";
        {
          ArgumentDocumentation a;
    
          a.name = "hostname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Hostname";
        a.short_desc["de-DE"] = L"Hostname";
        a.short_desc["fr-FR"] = L"Le nom de l'hôte.";
        a.short_desc["cs-CZ"] = L"Hostname";
        a.long_desc["en"] = L"Name of the host. Sample: localhost.";
        a.long_desc["de-DE"] = L"Hostname.  Beispiel: localhost.";
        a.long_desc["fr-FR"] = L"Le nom de l'hôte. Sample: localhost.";
        a.long_desc["cs-CZ"] = L"Name of the host. Sample: localhost.";
      
          fd.arg_pool["hostname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "port";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Port";
        a.short_desc["de-DE"] = L"Port";
        a.short_desc["fr-FR"] = L"Port";
        a.short_desc["cs-CZ"] = L"Port";
        a.long_desc["en"] = L"Port";
        a.long_desc["de-DE"] = L"Port";
        a.long_desc["fr-FR"] = L"Port";
        a.long_desc["cs-CZ"] = L"Port";
      
          fd.arg_pool["port"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "username";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Username";
        a.short_desc["de-DE"] = L"Benutzername";
        a.short_desc["fr-FR"] = L"Nom d'utilisateur";
        a.short_desc["cs-CZ"] = L"Username";
        a.long_desc["en"] = L"Username";
        a.long_desc["de-DE"] = L"Benutzername";
        a.long_desc["fr-FR"] = L"Nom d'utilisateur";
        a.long_desc["cs-CZ"] = L"Username";
      
          fd.arg_pool["username"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "pw_hash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Pw_hash";
        a.short_desc["de-DE"] = L"Pw_hash";
        a.short_desc["fr-FR"] = L"Pw_Codage";
        a.short_desc["cs-CZ"] = L"Pw_hash";
        a.long_desc["en"] = L"Pw_hash";
        a.long_desc["de-DE"] = L"Pw_hash";
        a.long_desc["fr-FR"] = L"Pw_Codage";
        a.long_desc["cs-CZ"] = L"Pw_hash";
      
          fd.arg_pool["pw_hash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "forcecheck";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("bool");
    
        a.short_desc["en"] = L"";
        a.short_desc["de-DE"] = L"";
        a.short_desc["fr-FR"] = L"";
        a.short_desc["cs-CZ"] = L"";
        a.long_desc["en"] = L"";
        a.long_desc["de-DE"] = L"";
        a.long_desc["fr-FR"] = L"";
        a.long_desc["cs-CZ"] = L"";
      
          fd.arg_pool["forcecheck"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("hostname");
          p.arg_keys.push_back("port");
          p.arg_keys.push_back("username");
          p.arg_keys.push_back("pw_hash");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("hostname");
          p.arg_keys.push_back("port");
          p.arg_keys.push_back("username");
          p.arg_keys.push_back("pw_hash");
          p.arg_keys.push_back("forcecheck");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloRegisterServer";
        fd.c_name = "palo_register_server";
        
        fd.xl_doc.xl_name = "PALO.REGISTER";
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Registers a PALO server for use with the PALO Client Library.";
        fd.short_desc["de-DE"] = L"Registriert einen PALO-Server für die Benutzung mit der PALO-Client-Bibliothek";
        fd.short_desc["fr-FR"] = L"Enregistre un serveur PALO pour l' utilisation avec la bibliothèque PALO Client.";
        fd.short_desc["cs-CZ"] = L"Registers a PALO server for use with the PALO Client Library.";
        fd.long_desc["en"] = L"Registers a PALO server for use with the PALO Client Library.";
        fd.long_desc["de-DE"] = L"Registriert einen PALO-Server für die Benutzung mit der PALO-Client-Bibliothek";
        fd.long_desc["fr-FR"] = L"Enregistre un serveur PALO pour l'utilisation avec la bibliothèque PALO Client.";
        fd.long_desc["cs-CZ"] = L"Registers a PALO server for use with the PALO Client Library.";
        {
          ArgumentDocumentation a;
    
          a.name = "localname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Localname";
        a.short_desc["de-DE"] = L"Lokaler Name";
        a.short_desc["fr-FR"] = L"Le nom local";
        a.short_desc["cs-CZ"] = L"Localname";
        a.long_desc["en"] = L"Name of the server (localhost).";
        a.long_desc["de-DE"] = L"Name des Servers (localhost)";
        a.long_desc["fr-FR"] = L"Le nom du serveur (localhost)";
        a.long_desc["cs-CZ"] = L"Name of the server (localhost).";
      
          fd.arg_pool["localname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "hostname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Hostname";
        a.short_desc["de-DE"] = L"Hostname";
        a.short_desc["fr-FR"] = L"Le nom de l'hôte.";
        a.short_desc["cs-CZ"] = L"Hostname";
        a.long_desc["en"] = L"Host IP (sample: 127.0.0.1)";
        a.long_desc["de-DE"] = L"Host IP (Beispiel: 127.0.0.1)";
        a.long_desc["fr-FR"] = L"Host_IP (exemple:127.0.0.1)";
        a.long_desc["cs-CZ"] = L"Host IP (sample: 127.0.0.1)";
      
          fd.arg_pool["hostname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "port";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Port";
        a.short_desc["de-DE"] = L"Port";
        a.short_desc["fr-FR"] = L"Port";
        a.short_desc["cs-CZ"] = L"Port";
        a.long_desc["en"] = L"Port (sample: 7777)";
        a.long_desc["de-DE"] = L"Port (Beispiel: 7777)";
        a.long_desc["fr-FR"] = L"Port (exemple:7777)";
        a.long_desc["cs-CZ"] = L"Port (sample: 7777)";
      
          fd.arg_pool["port"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "username";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Username";
        a.short_desc["de-DE"] = L"Benutzername";
        a.short_desc["fr-FR"] = L"Nom d'utilisateur";
        a.short_desc["cs-CZ"] = L"Username";
        a.long_desc["en"] = L"Username";
        a.long_desc["de-DE"] = L"Benutzername";
        a.long_desc["fr-FR"] = L"Nom d'utilisateur";
        a.long_desc["cs-CZ"] = L"Username";
      
          fd.arg_pool["username"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "pw_hash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Pw_hash";
        a.short_desc["de-DE"] = L"Pw_hash";
        a.short_desc["fr-FR"] = L"Pw_codage";
        a.short_desc["cs-CZ"] = L"Pw_hash";
        a.long_desc["en"] = L"Pw_hash";
        a.long_desc["de-DE"] = L"Pw_hash";
        a.long_desc["fr-FR"] = L"Pw_codage";
        a.long_desc["cs-CZ"] = L"Pw_hash";
      
          fd.arg_pool["pw_hash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dologin";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("bool");
    
        a.short_desc["en"] = L"";
        a.short_desc["de-DE"] = L"";
        a.short_desc["fr-FR"] = L"";
        a.short_desc["cs-CZ"] = L"";
        a.long_desc["en"] = L"";
        a.long_desc["de-DE"] = L"";
        a.long_desc["fr-FR"] = L"";
        a.long_desc["cs-CZ"] = L"";
      
          fd.arg_pool["dologin"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("localname");
          p.arg_keys.push_back("hostname");
          p.arg_keys.push_back("port");
          p.arg_keys.push_back("username");
          p.arg_keys.push_back("pw_hash");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("localname");
          p.arg_keys.push_back("hostname");
          p.arg_keys.push_back("port");
          p.arg_keys.push_back("username");
          p.arg_keys.push_back("pw_hash");
          p.arg_keys.push_back("dologin");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementPrev";
        fd.c_name = "palo_eprev";
        
        fd.xl_doc.xl_name = "PALO.EPREV";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the preceding element in the dimension";
        fd.short_desc["de-DE"] = L"Liefert den Namen des in der Dimension davorstehenden Elementes";
        fd.short_desc["fr-FR"] = L"Indique le nom de l’élément antéposé.";
        fd.short_desc["cs-CZ"] = L"Vrátí název předchozího prvku v dimenzi.";
        fd.long_desc["en"] = L"Returns the name of the preceding element in the dimension";
        fd.long_desc["de-DE"] = L"Liefert den Namen des in der Dimension davorstehenden Elementes";
        fd.long_desc["fr-FR"] = L"Indique le nom de l’élément antéposé d’une dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí název předchozího prvku v dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.The previous element of this element will be displayed.";
        a.long_desc["de-DE"] = L"Als Parameter wird der Name des im Index folgenden Elementes angegeben. Es wird dann das im Index davorstehende Element ausgegeben";
        a.long_desc["fr-FR"] = L"Nom de l’élément est indiqué en tant que paramètre, l’élément est indiqué dans la position antérieure.";
        a.long_desc["cs-CZ"] = L"Název prvku. Bude zobrazen prvek, který předchází tomuto.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementNext";
        fd.c_name = "palo_enext";
        
        fd.xl_doc.xl_name = "PALO.ENEXT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the succeeding element in the dimension";
        fd.short_desc["de-DE"] = L"Liefert den Namen des in der Dimension nachfolgenden Elementes";
        fd.short_desc["fr-FR"] = L"Renvoie le nom de l’élément suivant dans la position.";
        fd.short_desc["cs-CZ"] = L"Vrátí název následujícího prvku v dimenzi.";
        fd.long_desc["en"] = L"Returns the name of the succeeding element in the dimension";
        fd.long_desc["de-DE"] = L"Liefert den Namen des in der Dimension nachfolgenden Elementes";
        fd.long_desc["fr-FR"] = L"Renvoie le nom de l’élément suivant dans la position.";
        fd.long_desc["cs-CZ"] = L"Vrátí název následujícího prvku v dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element. The next element of this element will be displayed.";
        a.long_desc["de-DE"] = L"Als Parameter wird der Name des im Index vorangehenden Elementes angegeben. Es wird dann das im Index darauffolgende Element ausgegeben";
        a.long_desc["fr-FR"] = L"Nom de l’élément est indiqué en tant que paramètre, l’élément suivant dans la position sera renvoyé.";
        a.long_desc["cs-CZ"] = L"Název prvku. Bude zobrazen prvek, který následuje po tomto.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementChildname";
        fd.c_name = "palo_echildname";
        
        fd.xl_doc.xl_name = "PALO.ECHILD";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the specified child element";
        fd.short_desc["de-DE"] = L"Liefert den Namen des bestimmten Kindelementes";
        fd.short_desc["fr-FR"] = L"Donne le nom de l’élément enfant défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí název určeného prvku potomka.";
        fd.long_desc["en"] = L"Returns the name of the specified child element";
        fd.long_desc["de-DE"] = L"Liefert den Namen des bestimmten Kindelementes";
        fd.long_desc["fr-FR"] = L"Donne le nom de l’élément enfant défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí název určeného prvku potomka.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à indiquer.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the parent element which contains the child element.";
        a.long_desc["de-DE"] = L"Name des Elternelementes, welches das anzuzeigende Kindelement enthält";
        a.long_desc["fr-FR"] = L"Nom de l’élément parent qui contient l’élément enfant.";
        a.long_desc["cs-CZ"] = L"Název rodičovského prvku, který obsahuje dítě.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Index number, that specifies the child element";
        a.long_desc["de-DE"] = L"Indexnummer, die das Kindelement festlegt";
        a.long_desc["fr-FR"] = L"Numéro de position qui définit l’élément enfant.";
        a.long_desc["cs-CZ"] = L"Index čísla, které určuje prvek dítěte.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Index");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementCreateBulk";
        fd.c_name = "palo_element_create_bulk";
        fd.short_desc["en"] = L"Returns the name of the specified child element";
        fd.short_desc["de-DE"] = L"Liefert den Namen des bestimmten Kindelementes";
        fd.short_desc["fr-FR"] = L"Retourne le nom de l'élément enfant spécifié.";
        fd.short_desc["cs-CZ"] = L"Returns the name of the specified child element";
        fd.long_desc["en"] = L"Returns the name of the specified child element";
        fd.long_desc["de-DE"] = L"Liefert den Namen des bestimmten Kindelementes";
        fd.long_desc["fr-FR"] = L"Retourne le nom de l'élément enfant spécifié.";
        fd.long_desc["cs-CZ"] = L"Returns the name of the specified child element";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ElementArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the parent element, which contains the child element.";
        a.long_desc["de-DE"] = L"Name des Elternelementes, welches das anzuzeigende Kindelement enthält";
        a.long_desc["fr-FR"] = L"Nom de l'élément parent qui contient l'élément enfant.";
        a.long_desc["cs-CZ"] = L"Name of the parent element, which contains the child element.";
      
          fd.arg_pool["ElementArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Typ";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Index number, that specifies the child element";
        a.long_desc["de-DE"] = L"Indexnummer, die das Kindelement festlegt";
        a.long_desc["fr-FR"] = L"Numéro d'index, qui spécifie l'enfant élément.";
        a.long_desc["cs-CZ"] = L"Index number, that specifies the child element";
      
          fd.arg_pool["Typ"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ChildrenArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Empty String";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
      
          fd.arg_pool["ChildrenArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "WeightArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Empty String";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
      
          fd.arg_pool["WeightArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "EmptyString";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Empty String";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
      
          fd.arg_pool["EmptyString"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("ElementArray");
          p.arg_keys.push_back("Typ");
          p.arg_keys.push_back("ChildrenArray");
          p.arg_keys.push_back("WeightArray");
          p.arg_keys.push_back("EmptyString");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementFirst";
        fd.c_name = "palo_efirst";
        
        fd.xl_doc.xl_name = "PALO.EFIRST";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the first element in the specified dimension";
        fd.short_desc["de-DE"] = L"Liefert das erste Element der angegebenen Dimension";
        fd.short_desc["fr-FR"] = L"Donne le premier élément dans la dimension/les éléments parent.";
        fd.short_desc["cs-CZ"] = L"Vrátí první prvek v určené dimenzi";
        fd.long_desc["en"] = L"Returns the first element in the specified dimension";
        fd.long_desc["de-DE"] = L"Liefert das erste Element der angegebenen Dimension";
        fd.long_desc["fr-FR"] = L"Donne le premier élément dans la dimension/les éléments parent.";
        fd.long_desc["cs-CZ"] = L"Vrátí první prvek v určené dimenzi";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementChildcount";
        fd.c_name = "palo_echildcount";
        
        fd.xl_doc.xl_name = "PALO.ECHILDCOUNT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of children of the specified element";
        fd.short_desc["de-DE"] = L"Liefert die Anzahl der Kindelemente des angegebenen Elements";
        fd.short_desc["fr-FR"] = L"Donne le nombre des éléments enfant à partir de l’élément consolidé défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí počet potomků určeného prvku.";
        fd.long_desc["en"] = L"Returns the number of children of the specified element";
        fd.long_desc["de-DE"] = L"Liefert die Anzahl der Kindelemente des angegebenen Elements";
        fd.long_desc["fr-FR"] = L"Donne le nombre des éléments enfant à partir de l’élément consolidé défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí počet potomků určeného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément parent que contient l’élément enfant.";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementCount";
        fd.c_name = "palo_ecount";
        
        fd.xl_doc.xl_name = "PALO.ECOUNT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of elements in the specified dimension";
        fd.short_desc["de-DE"] = L"Liefert die Anzahl der Elemente einer Dimension";
        fd.short_desc["fr-FR"] = L"Donne le nombre d’éléments dans une dimension définie.";
        fd.short_desc["cs-CZ"] = L"Vrátí počet prvků v určené dimenzi.";
        fd.long_desc["en"] = L"Returns the number of elements in the specified dimension";
        fd.long_desc["de-DE"] = L"Liefert die Anzahl der Elemente einer Dimension";
        fd.long_desc["fr-FR"] = L"Donne le nombre d’éléments dans une dimension définie.";
        fd.long_desc["cs-CZ"] = L"Vrátí počet prvků v určené dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementIndex";
        fd.c_name = "palo_eindex";
        
        fd.xl_doc.xl_name = "PALO.EINDEX";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the position of the specified element in the dimension";
        fd.short_desc["de-DE"] = L"Gibt die Position des beschriebenen Elements in der Dimension zurück";
        fd.short_desc["fr-FR"] = L"Renvoie la position de l’élément indiqué dans la dimension.";
        fd.short_desc["cs-CZ"] = L"Vrátí pozici určeného prvku v dimenzi.";
        fd.long_desc["en"] = L"Returns the position of the specified element in the dimension";
        fd.long_desc["de-DE"] = L"Gibt die Position des beschriebenen Elements in der Dimension zurück";
        fd.long_desc["fr-FR"] = L"Renvoie la position de l’élément indiqué dans la dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí pozici určeného prvku v dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element, whose index is to display.";
        a.long_desc["de-DE"] = L"Name des Elementes, dessen Index angezeigt werden soll";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont la position doit être affichée.";
        a.long_desc["cs-CZ"] = L"Název prvku, jehož index je zobrazen.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementIsChild";
        fd.c_name = "palo_eischild";
        
        fd.xl_doc.xl_name = "PALO.EISCHILD";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Checks if a parent element contains the specified element as child element";
        fd.short_desc["de-DE"] = L"Prüft, ob ein Elternelement ein bestimmtes Element als Kindelement enthält";
        fd.short_desc["fr-FR"] = L"Vérifie si un élément consolidé contient l’élément indiqué.";
        fd.short_desc["cs-CZ"] = L"Ověří, zda rodičovský prvek obsahuje určený prvek jako prvek dítěte.";
        fd.long_desc["en"] = L"Checks if a parent element contains the specified element as child element";
        fd.long_desc["de-DE"] = L"Prüft, ob ein Elternelement ein bestimmtes Element als Kindelement enthält";
        fd.long_desc["fr-FR"] = L"Vérifie si un élément consolidé contient l’élément indiqué.";
        fd.long_desc["cs-CZ"] = L"Ověří, zda rodičovský prvek obsahuje určený prvek jako prvek dítěte.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Parent Element";
        a.short_desc["de-DE"] = L"Elternelement";
        a.short_desc["fr-FR"] = L"Élément parent";
        a.short_desc["cs-CZ"] = L"Rodičovského prvku";
        a.long_desc["en"] = L"Name of the parent element.";
        a.long_desc["de-DE"] = L"Name des Elternelements";
        a.long_desc["fr-FR"] = L"Nom de l’élément parent.";
        a.long_desc["cs-CZ"] = L"Název rodičovského prvku";
      
          fd.arg_pool["Parent Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element, which is to be checked whether it is a child element.";
        a.long_desc["de-DE"] = L"Name des Elementes, dass geprüft werden soll, ob es ein Kindelement ist";
        a.long_desc["fr-FR"] = L"Nom de l’élément qui doit être vérifié s’il s’agit d’un élément enfant.";
        a.long_desc["cs-CZ"] = L"Název prvku, u kterého chcete zkontrolovat, zda se jedná o prvek dítěte.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Parent Element");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementName";
        fd.c_name = "palo_ename";
        
        fd.xl_doc.xl_name = "PALO.ENAME";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the element with the positionnumber INDEX (First element has positionnumber 1)";
        fd.short_desc["de-DE"] = L"Liefert den Namen des Elementes mit der Positionsnummer INDEX (Erstes Element hat die Positions-Nr. 1)";
        fd.short_desc["fr-FR"] = L"Renvoie le nom de l’élément à une position précise (la première position est 1).";
        fd.short_desc["cs-CZ"] = L"Vrátí název prvku s číslem 'index' (první prvek má index 1)";
        fd.long_desc["en"] = L"Returns the name of the element with the positionnumber INDEX (First element has positionnumber 1)";
        fd.long_desc["de-DE"] = L"Liefert den Namen des Elementes mit der Positionsnummer INDEX (Erstes Element hat die Positions-Nr. 1)";
        fd.long_desc["fr-FR"] = L"Renvoie le nom de l’élément à une position précise (la première position est 1).";
        fd.long_desc["cs-CZ"] = L"Vrátí název prvku s číslem 'index' (první prvek má index 1)";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Index number, that specifies the position of the element in the dimension";
        a.long_desc["de-DE"] = L"Indexnummer, welche die Position des Elements in der Dimension angibt";
        a.long_desc["fr-FR"] = L"Numéro de position qui définit l’élément à partir de la dimension utilisée.";
        a.long_desc["cs-CZ"] = L"Index je číslo, které určuje pozici prvku v dimenzi.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l'élément";
        a.long_desc["cs-CZ"] = L"Name of the element.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Attribute";
        a.short_desc["de-DE"] = L"Attribut";
        a.short_desc["fr-FR"] = L"Attribut";
        a.short_desc["cs-CZ"] = L"Attribute";
        a.long_desc["en"] = L"Name of the attribute.";
        a.long_desc["de-DE"] = L"Name des Attributes";
        a.long_desc["fr-FR"] = L"Nom de l'attribut";
        a.long_desc["cs-CZ"] = L"Name of the attribute.";
      
          fd.arg_pool["Attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Reserved";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Reserved";
        a.short_desc["de-DE"] = L"Reserviert";
        a.short_desc["fr-FR"] = L"Réservé";
        a.short_desc["cs-CZ"] = L"Reserved";
        a.long_desc["en"] = L"for internal use only";
        a.long_desc["de-DE"] = L"Nur für internen Gebrauch";
        a.long_desc["fr-FR"] = L"Seulement pour usage interne";
        a.long_desc["cs-CZ"] = L"for internal use only";
      
          fd.arg_pool["Reserved"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Attribute");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Attribute");
          p.arg_keys.push_back("Reserved");
          p.arg_keys.push_back("Reserved");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Index");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementParentcount";
        fd.c_name = "palo_eparentcount";
        
        fd.xl_doc.xl_name = "PALO.EPARENTCOUNT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of parent elements which contain the specified element as child element";
        fd.short_desc["de-DE"] = L"Liefert die Anzahl der Elternelemente, in welchen das angegebene Element als Kindelement konsolidiert ist";
        fd.short_desc["fr-FR"] = L"Donne le nombre des éléments consolidés qui contient l’élément parent défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí počet rodičovských prvků, které obsahují určený prvek jako dítě.";
        fd.long_desc["en"] = L"Returns the number of parent elements which contain the specified element as child element";
        fd.long_desc["de-DE"] = L"Liefert die Anzahl der Elternelemente, in welchen das angegebene Element als Kindelement konsolidiert ist";
        fd.long_desc["fr-FR"] = L"Donne le nombre des éléments consolidés qui contient l’élément parent défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí počet rodičovských prvků, které obsahují určený prvek jako dítě.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Bse de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient les éléments.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément parent qui contient les éléments enfant.";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementParentname";
        fd.c_name = "palo_eparentname";
        
        fd.xl_doc.xl_name = "PALO.EPARENT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the n th parent of the specified element";
        fd.short_desc["de-DE"] = L"Liefert den Namen des n-ten Elternelements des angegebenen Elements";
        fd.short_desc["fr-FR"] = L"Renvoie le nom de la partie parent énième de l’élément indiqué.";
        fd.short_desc["cs-CZ"] = L"Vrátí název n-tého rodiče určeného prvku.";
        fd.long_desc["en"] = L"Returns the name of the n th parent of the specified element";
        fd.long_desc["de-DE"] = L"Liefert den Namen des n-ten Elternelements des angegebenen Elements";
        fd.long_desc["fr-FR"] = L"Renvoie le nom de la partie parent énième de l’élément indiqué.";
        fd.long_desc["cs-CZ"] = L"Vrátí název n-tého rodiče určeného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont l’élément parent doit être renvoyé.";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Number of the parent element to retrieve.";
        a.long_desc["de-DE"] = L"Nummer des Elternelements, das zurückgegeben werden soll";
        a.long_desc["fr-FR"] = L"Numéro de position de l’élément qui doit être renvoyé.";
        a.long_desc["cs-CZ"] = L"Počet rodičovských prvků, které chcete vrátit.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Index");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementType";
        fd.c_name = "palo_etype";
        
        fd.xl_doc.xl_name = "PALO.ETYPE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the type of the specified element";
        fd.short_desc["de-DE"] = L"Gibt den Typ des Elementes zurück";
        fd.short_desc["fr-FR"] = L"Renvoie le nom de l’élément défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí typ určeného prvku";
        fd.long_desc["en"] = L"Returns the type of the specified element";
        fd.long_desc["de-DE"] = L"Gibt den Typ des Elementes zurück";
        fd.long_desc["fr-FR"] = L"Renvoie le nom de l’élément défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí typ určeného prvku";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element which type should be retrieved.";
        a.long_desc["de-DE"] = L"Name des Elementes, dessen Typ ausgegeben werden soll";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont le type est indiqué.";
        a.long_desc["cs-CZ"] = L"Název prvku, jehož typ chcete vrátit.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementSibling";
        fd.c_name = "palo_esibling";
        
        fd.xl_doc.xl_name = "PALO.ESIBLING";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the name of the specified sibling";
        fd.short_desc["de-DE"] = L"Liefert den Namen des angegebenen Geschwisterelements";
        fd.short_desc["fr-FR"] = L"Renvoie le nom de l’élément frère défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí název určeného sourozence";
        fd.long_desc["en"] = L"Returns the name of the specified sibling";
        fd.long_desc["de-DE"] = L"Liefert den Namen des angegebenen Geschwisterelements";
        fd.long_desc["fr-FR"] = L"Renvoie le nom de l’élément frère défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí název určeného sourozence.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient frère.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont l’élément défini enfant doit être indiqué.";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Index number, which determines the sibling element";
        a.long_desc["de-DE"] = L"Indexnummer, mit der das Schwesternelement bestimmt wird";
        a.long_desc["fr-FR"] = L"Numéro de position avec lequel l’élément frère est défini.";
        a.long_desc["cs-CZ"] = L"Číslo (index), které určuje prvek sourozence";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Index");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdata";
        fd.c_name = "palo_setdata";
        
        fd.xl_doc.xl_name = "PALO.SETDATA";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Sets a value of a cube cell";
        fd.short_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle";
        fd.short_desc["fr-FR"] = L"Établit la valeur d’un élément défini. Pour entrer des valeurs consolidées, le paramètre-Splash est paramétré sur \"VRAI\", dans le cas où il s’agit d’un élément de base, il sera paramétré sur \"Faux\" car la valeur ne peut être répartie dans des éléments de base.";
        fd.short_desc["cs-CZ"] = L"Zapíše hodnotu do buňky kostky";
        fd.long_desc["en"] = L"Sets a value of a cube cell";
        fd.long_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle";
        fd.long_desc["fr-FR"] = L"Établit la valeur d’un élément défini. Pour entrer des valeurs consolidées, le paramètre-Splash est paramétré sur \"VRAI\", dans le cas où il s’agit d’un élément de base, il sera paramétré sur \"Faux\" car la valeur ne peut être répartie dans des éléments de base.";
        fd.long_desc["cs-CZ"] = L"Zapíše hodnotu do buňky kostky";
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Hodnota";
        a.long_desc["en"] = L"The value to be written (string or double).";
        a.long_desc["de-DE"] = L"Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = L"Valeur devient (String ou Double)";
        a.long_desc["cs-CZ"] = L"Hodnota, která bude nastavená (typu řetězec nebo double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Splash";
        a.short_desc["de-DE"] = L"Splash";
        a.short_desc["fr-FR"] = L"Splash";
        a.short_desc["cs-CZ"] = L"Splash";
        a.long_desc["en"] = L"TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = L"WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = L"\"VRAI\" s’il est écrit dans un élément consolidé. \"FAUX\" s’il est écrit dans un élément de base.";
        a.long_desc["cs-CZ"] = L"\"Pravda\", jestliže se odkazujete na konsolidovanou buňku. \"Nepravda\", jestliže se odkazujete na základní buňku.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
        a.long_desc["cs-CZ"] = L"Koordináty v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Splash");
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdataIf";
        fd.c_name = "palo_setdataif";
        
        fd.xl_doc.xl_name = "PALO.SETDATAIF";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Sets a value of a cube cell if the condition is true";
        fd.short_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.short_desc["fr-FR"] = L"Écrit une valeur dans une cellule de cube, si la condition est vraie";
        fd.short_desc["cs-CZ"] = L"Nastaví hodnotu při splnění určité podmínky (bude pravdivá).";
        fd.long_desc["en"] = L"Sets a value of a cube cell if the condition is true";
        fd.long_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.long_desc["fr-FR"] = L"Écrit une valeur dans une cellule de cube, si la condition est vraie";
        fd.long_desc["cs-CZ"] = L"Nastaví hodnotu při splnění určité podmínky (bude pravdivá).";
        {
          ArgumentDocumentation a;
    
          a.name = "Condition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Condition";
        a.short_desc["de-DE"] = L"Bedingung";
        a.short_desc["fr-FR"] = L"Condition";
        a.short_desc["cs-CZ"] = L"Podmínka";
        a.long_desc["en"] = L"The condition to be met";
        a.long_desc["de-DE"] = L"Die Bedingung, die erfüllt sein muss";
        a.long_desc["fr-FR"] = L"La condition pour l'action";
        a.long_desc["cs-CZ"] = L"Podmínka je hodnota nebo výraz, který bude mít logickou hodnotu PRAVDA nebo NEPRAVDA.";
      
          fd.arg_pool["Condition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Hodnota";
        a.long_desc["en"] = L"Value to be written(string or double)";
        a.long_desc["de-DE"] = L"Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = L"Valeur devient (String oder Double)";
        a.long_desc["cs-CZ"] = L"Hodnota, která bude nastavená (typu řetězec nebo double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Splash";
        a.short_desc["de-DE"] = L"Splash";
        a.short_desc["fr-FR"] = L"Splash";
        a.short_desc["cs-CZ"] = L"Splash";
        a.long_desc["en"] = L"TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = L"WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = L"\"VRAI\" s’il est écrit dans un élément consolidé. \"FAUX\" s’il est écrit dans un élément de base.";
        a.long_desc["cs-CZ"] = L"\"Pravda\", jestliže se odkazujete na konsolidovanou buňku. \"Nepravda\", jestliže se odkazujete na základní buňku.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordinate";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans lequel les dimenisons sont créés dans le cube";
        a.long_desc["cs-CZ"] = L"Koordináty v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Condition");
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Splash");
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdataAIf";
        fd.c_name = "palo_setdataaif";
        
        fd.xl_doc.xl_name = "PALO.SETDATAAIF";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Sets a value of a cube cell if the condition is true";
        fd.short_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.short_desc["fr-FR"] = L"Écrit une valeur dans une cellule de cube, si la condition est vraie.";
        fd.short_desc["cs-CZ"] = L"Sets a value of a cube cell if the condition is true";
        fd.long_desc["en"] = L"Sets a value of a cube cell if the condition is true";
        fd.long_desc["de-DE"] = L"Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.long_desc["fr-FR"] = L"Écrit une valeur dans une cellule de cube, si la condition est vraie.";
        fd.long_desc["cs-CZ"] = L"Sets a value of a cube cell if the condition is true";
        {
          ArgumentDocumentation a;
    
          a.name = "Condition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Condition";
        a.short_desc["de-DE"] = L"Bedingung";
        a.short_desc["fr-FR"] = L"Condition";
        a.short_desc["cs-CZ"] = L"Condition";
        a.long_desc["en"] = L"The condition to be met.";
        a.long_desc["de-DE"] = L"Die Bedingung, die erfüllt sein muss";
        a.long_desc["fr-FR"] = L"La condition à remplir.";
        a.long_desc["cs-CZ"] = L"The condition to be met.";
      
          fd.arg_pool["Condition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Value";
        a.long_desc["en"] = L"Value to be written(string or double)";
        a.long_desc["de-DE"] = L"Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = L"La valeur à écrire (String ou double)";
        a.long_desc["cs-CZ"] = L"Value to be written(string or double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Splash";
        a.short_desc["de-DE"] = L"Splash";
        a.short_desc["fr-FR"] = L"Splash";
        a.short_desc["cs-CZ"] = L"Splash";
        a.long_desc["en"] = L"TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = L"WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = L"VRAI s'il est écrit dans une cellule consolidée. FAUX s'il est écrit dans une cellule de base.";
        a.long_desc["cs-CZ"] = L"TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Name of the cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Condition");
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Splash");
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdataWrap";
        fd.c_name = "palo_setdata_wrap";
        
        fd.xl_doc.xl_name = "PALO.SETDATA_WRAP";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans l'ordre que dans le cube.";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataV";
        fd.c_name = "palo_datav";
        
        fd.xl_doc.xl_name = "PALO.DATAV";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the value of the specified cell from the cube.";
        fd.short_desc["de-DE"] = L"Liefert den Wert einer angegebenen Würfelzelle ";
        fd.short_desc["fr-FR"] = L"Renvoie la valeur d’une cellule de données à partir du cube si vous utilisez une fonction Excel matrice. ";
        fd.short_desc["cs-CZ"] = L"Vrátí hodnotu určené buňky z kostky.";
        fd.long_desc["en"] = L"Returns the value of the specified cell from the cube.";
        fd.long_desc["de-DE"] = L"Liefert den Wert einer angegebenen Würfelzelle ";
        fd.long_desc["fr-FR"] = L"Renvoie la valeur d’une cellule de données à partir du cube si vous utilisez une fonction Excel matrice. ";
        fd.long_desc["cs-CZ"] = L"Vrátí hodnotu určené buňky z kostky.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Plage de coordonnées dont les valeurs doivent être affichées. Les coordonnées sont précisées dans une matrice dans le même ordre que dans le cube mentionné. ";
        a.long_desc["cs-CZ"] = L"Koordináty1,Koordináty2,... v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdata";
        fd.c_name = "palo_data";
        
        fd.xl_doc.xl_name = "PALO.DATA";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the value of a cell from the cube.";
        fd.short_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel aus. ";
        fd.short_desc["fr-FR"] = L"Lit la valeur de la cellule de données indiquée à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Vrátí hodnotu buňky z kostky";
        fd.long_desc["en"] = L"Returns the value of the specified element from the cube";
        fd.long_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel aus. ";
        fd.long_desc["fr-FR"] = L"Lit la valeur de la cellule de données indiquée à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Vrátí hodnotu určeného prvku z kostky.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube. ";
        a.long_desc["cs-CZ"] = L"Koordináty1,Koordináty2,... v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataC";
        fd.c_name = "palo_datac";
        
        fd.xl_doc.xl_name = "PALO.DATAC";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the value of a cell from the cube";
        fd.short_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel aus ";
        fd.short_desc["fr-FR"] = L"Lit la valeur de la cellule de données indiquée à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Vrátí hodnotu buňky z kostky.";
        fd.long_desc["en"] = L"Returns the value of a cell from the cube.";
        fd.long_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel aus. ";
        fd.long_desc["fr-FR"] = L"Lit la valeur de la cellule de données indiquée à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Vrátí hodnotu buňky z kostky";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube. ";
        a.long_desc["cs-CZ"] = L"Koordináty1,Koordináty2,... v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataX";
        fd.c_name = "palo_datax";
        
        fd.xl_doc.xl_name = "PALO.DATAX";
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the value of a cell from the cube only if the function is on the active sheet.";
        fd.short_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel. Funktioniert nur, wenn sich die Funktion auf dem aktuellen Tabellenblatt befindet ";
        fd.short_desc["fr-FR"] = L"Renvoie la valeur d’un élément défini. Fonctionne seulement si la cellule se trouve sur la même feuille. ";
        fd.short_desc["cs-CZ"] = L"Returns the value of a cell from the cube only if the function is on the active sheet.";
        fd.long_desc["en"] = L"Returns the value of a cell from the cube only if the function is on the active sheet.";
        fd.long_desc["de-DE"] = L"Liest den Wert einer Datenzelle aus dem Würfel. Funktioniert nur, wenn sich die Funktion auf dem aktuellen Tabellenblatt befindet ";
        fd.long_desc["fr-FR"] = L"Renvoie la valeur d’un élément défini. Fonctionne seulement si la cellule se trouve sur la même feuille. ";
        fd.long_desc["cs-CZ"] = L"Returns the value of a cell from the cube only if the function is on the active sheet.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube. ";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataT";
        fd.c_name = "palo_datat";
        
        fd.xl_doc.xl_name = "PALO.DATAT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the value of the specified string element.";
        fd.short_desc["de-DE"] = L"Liest den Wert der beschriebenen Textzelle aus dem Würfel aus bzw. gibt diesen zurück ";
        fd.short_desc["fr-FR"] = L"Lit la valeur d’une cellule texte indiquée à partir du cube ou bien renvoie compte du cube. ";
        fd.short_desc["cs-CZ"] = L"Vrátí hodnotu určeného textového prvku.";
        fd.long_desc["en"] = L"Returns the value of the specified string element.";
        fd.long_desc["de-DE"] = L"Liest den Wert der beschriebenen Textzelle aus dem Würfel aus bzw. gibt diesen zurück ";
        fd.long_desc["fr-FR"] = L"Lit la valeur d’une cellule texte indiquée à partir du cube ou bien renvoie compte du cube. ";
        fd.long_desc["cs-CZ"] = L"Vrátí hodnotu určeného textového prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube. ";
        a.long_desc["cs-CZ"] = L"Koordináty1,Koordináty2,... v pořadí, v jakém jsou v kostce";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataTC";
        fd.c_name = "palo_datatc";
        
        fd.xl_doc.xl_name = "PALO.DATATC";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters";
        fd.short_desc["de-DE"] = L"Gibt Daten entsprechend den Koordinaten zurück, ansonsten wird error zurückgegeben, wenn die Daten nicht abgerufen werden können. Es werden nur 255 Zeichen dargestellt ";
        fd.short_desc["fr-FR"] = L"Retourne les données aux coordonnées spécifiées ou d'erreur si les données n'ont pu être récupérés (version mise en cache). Il sera affichée seulement 255 caractères. ";
        fd.short_desc["cs-CZ"] = L"Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters";
        fd.long_desc["en"] = L"Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters.";
        fd.long_desc["de-DE"] = L"Gibt Daten entsprechend den Koordinaten zurück, ansonsten wird error zurückgegeben, wenn die Daten nicht abgerufen werden können. Es werden nur 255 Zeichen dargestellt ";
        fd.long_desc["fr-FR"] = L"Retourne les données aux coordonnées spécifiées ou d'erreur si les données n'ont pu être récupérés (version mise en cache). Il sera affichée seulement 255 caractères. ";
        fd.long_desc["cs-CZ"] = L"Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind ";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans l'ordre que dans le cube. ";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAT";
        fd.c_name = "palo_dataat";
        
        fd.xl_doc.xl_name = "PALO.DATAAT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée ";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée ";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataATC";
        fd.c_name = "palo_dataatc";
        
        fd.xl_doc.xl_name = "PALO.DATAATC";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels ";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée ";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée ";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataA";
        fd.c_name = "palo_dataa";
        
        fd.xl_doc.xl_name = "PALO.DATAA";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels ";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée ";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée ";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAC";
        fd.c_name = "palo_dataac";
        
        fd.xl_doc.xl_name = "PALO.DATAAC";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels ";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée ";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée ";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdataA";
        fd.c_name = "palo_setdataa";
        
        fd.xl_doc.xl_name = "PALO.SETDATAA";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Value";
        a.long_desc["en"] = L"Value";
        a.long_desc["de-DE"] = L"Wert";
        a.long_desc["fr-FR"] = L"Valeur";
        a.long_desc["cs-CZ"] = L"Value";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Splash";
        a.short_desc["de-DE"] = L"Splash";
        a.short_desc["fr-FR"] = L"Splash";
        a.short_desc["cs-CZ"] = L"Splash";
        a.long_desc["en"] = L"Splash";
        a.long_desc["de-DE"] = L"Splash";
        a.long_desc["fr-FR"] = L"Splash";
        a.long_desc["cs-CZ"] = L"Splash";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Splash");
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSetdataAWrap";
        fd.c_name = "palo_setdataa_wrap";
        
        fd.xl_doc.xl_name = "PALO.SETDATAA_WRAP";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate Array";
        a.short_desc["de-DE"] = L"Koordinatenarray";
        a.short_desc["fr-FR"] = L"Array coordinée";
        a.short_desc["cs-CZ"] = L"Coordinate Array";
        a.long_desc["en"] = L"Coordinate Array";
        a.long_desc["de-DE"] = L"Koordinatenarray";
        a.long_desc["fr-FR"] = L"Array coordinée";
        a.long_desc["cs-CZ"] = L"Coordinate Array";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Value";
        a.long_desc["en"] = L"Value";
        a.long_desc["de-DE"] = L"Wert";
        a.long_desc["fr-FR"] = L"Valeur";
        a.long_desc["cs-CZ"] = L"Value";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Splash";
        a.short_desc["de-DE"] = L"Splash";
        a.short_desc["fr-FR"] = L"Splash";
        a.short_desc["cs-CZ"] = L"Splash";
        a.long_desc["en"] = L"Splash";
        a.long_desc["de-DE"] = L"Splash";
        a.long_desc["fr-FR"] = L"Splash";
        a.long_desc["cs-CZ"] = L"Splash";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinate Array");
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Splash");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementWeight";
        fd.c_name = "palo_eweight";
        
        fd.xl_doc.xl_name = "PALO.EWEIGHT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the consolidation weight of a specified component of an element.";
        fd.short_desc["de-DE"] = L"Gibt den Gewichtungsfaktor des beschriebenen Elements bei der Konsolidierung zurück";
        fd.short_desc["fr-FR"] = L"Renvoie le facteur de pondération de l’élément indiqué lors de la consolidation.";
        fd.short_desc["cs-CZ"] = L"Vrátí váhu prvku pro konsolidaci určeného prvku.";
        fd.long_desc["en"] = L"Returns the consolidation weight of a specified component of an element.";
        fd.long_desc["de-DE"] = L"Gibt den Gewichtungsfaktor des beschriebenen Elements bei der Konsolidierung zurück";
        fd.long_desc["fr-FR"] = L"Renvoie le facteur de pondération de l’élément indiqué lors de la consolidation.";
        fd.long_desc["cs-CZ"] = L"Vrátí váhu pro konsolidaci určené komponenty prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à indiquer.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Parent";
        a.short_desc["de-DE"] = L"Elternelement";
        a.short_desc["fr-FR"] = L"Élément parent";
        a.short_desc["cs-CZ"] = L"Rodičovského prvku";
        a.long_desc["en"] = L"Name of the consolidation element (Parent Element).";
        a.long_desc["de-DE"] = L"Name des konsolidierten Elements (Elternelement)";
        a.long_desc["fr-FR"] = L"Nom de l’élément consolidé (élément parent)";
        a.long_desc["cs-CZ"] = L"Název rodičovského prvku";
      
          fd.arg_pool["Parent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Child";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Name of the child element.";
        a.short_desc["de-DE"] = L"Name des Kindelements";
        a.short_desc["fr-FR"] = L"Nom de l'élément enfant.";
        a.short_desc["cs-CZ"] = L"Název prvku dítěte";
        a.long_desc["en"] = L"Name of the child element";
        a.long_desc["de-DE"] = L"Name des Kindelements";
        a.long_desc["fr-FR"] = L"Nom  de l’élément enfant";
        a.long_desc["cs-CZ"] = L"Název prvku dítěte";
      
          fd.arg_pool["Child"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Parent");
          p.arg_keys.push_back("Child");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementLevel";
        fd.c_name = "palo_elevel";
        
        fd.xl_doc.xl_name = "PALO.ELEVEL";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of hierarchical levels which are below an element.";
        fd.short_desc["de-DE"] = L"Gibt die Anzahl der Hierarchieebenen an, die unterhalb eines Elementes liegen";
        fd.short_desc["fr-FR"] = L"Indique le nombre de degrés de hiérarchie à l’intérieur de la dimension qui existe encore après l’élément.";
        fd.short_desc["cs-CZ"] = L"Vrátí úroveň určeného prvku v hierarchii dimenze.";
        fd.long_desc["en"] = L"Returns the number of hierarchical levels which are below an element.";
        fd.long_desc["de-DE"] = L"Gibt die Anzahl der Hierarchieebenen an, die unterhalb eines Elementes liegen";
        fd.long_desc["fr-FR"] = L"Indique le nombre de degrés de hiérarchie à l’intérieur de la dimension qui existe encore après l’élément.";
        fd.long_desc["cs-CZ"] = L"Vrátí úroveň určeného prvku v hierarchii dimenze.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element whose number of underlying levels should be returned.";
        a.long_desc["de-DE"] = L"Name des Elementes, dessen darunterliegende Hierarchieebenenanzahl ausgegeben werden soll";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont le niveau, selon les degrés de hiérarchie à l’intérieur de la dimension, doit être indiqué selon l’élément à suivre.";
        a.long_desc["cs-CZ"] = L"Název prvku, jehož úroveň chcete získat.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementIndent";
        fd.c_name = "palo_eindent";
        
        fd.xl_doc.xl_name = "PALO.EINDENT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the level of an element within a hierarchy (without parent-element: level 1, with one parent-level: level 2, etc.";
        fd.short_desc["de-DE"] = L"Gibt die Stufe eines Elements innerhalb einer Hierarchie zurück (ohne Elternelement:Stufe 1, eine Elternebene darüber:Stufe 2, usw.";
        fd.short_desc["fr-FR"] = L"Renvoie le degré de hiérarchie d’un élément à l’intérieur de la dimension.";
        fd.short_desc["cs-CZ"] = L"Vrátí úroveň prvku v hierarchii (bez rodičovského prvku: úroveň 1, s jedním rodičovským prvkem = úroveň, atd.).";
        fd.long_desc["en"] = L"Returns the level of an element within a hierarchy (without parent-element: level 1, with one parent-level: level 2, etc.";
        fd.long_desc["de-DE"] = L"Gibt die Stufe eines Elements innerhalb einer Hierarchie zurück (ohne Elternelement:Stufe 1, eine Elternebene darüber:Stufe 2, usw.";
        fd.long_desc["fr-FR"] = L"Renvoie le degré de hiérarchie d’un élément à l’intérieur de la dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí úroveň prvku v hierarchii (bez rodičovského prvku: úroveň 1, s jedním rodičovským prvkem = úroveň, atd.).";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à donner.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element whose hierarchy-level should be returned.";
        a.long_desc["de-DE"] = L"Name des Elementes, dessen Hierarchiestufe zurückgegeben werden soll";
        a.long_desc["fr-FR"] = L"Nom de l’élément dont le degré de hiérarchie doit être renvoyé à l’intérieur de la dimension.";
        a.long_desc["cs-CZ"] = L"Název prvku, jehož úroveň v hierarchii chcete získat.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionMaxLevel";
        fd.c_name = "palo_etoplevel";
        
        fd.xl_doc.xl_name = "PALO.ETOPLEVEL";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of the parent-levels in a dimension.";
        fd.short_desc["de-DE"] = L"Gibt die Anzahl der Elternebenen in einer Dimension zurück.";
        fd.short_desc["fr-FR"] = L"Renvoie le niveau le plus élevé que possède un élément dans la hiérarchie de consolidation de la dimension indiquée.";
        fd.short_desc["cs-CZ"] = L"Vrátí počet rodičovských úrovní v dimenzi.";
        fd.long_desc["en"] = L"Returns the number of the parent-levels in a dimension.";
        fd.long_desc["de-DE"] = L"Gibt die Anzahl der Elternebenen in einer Dimension zurück";
        fd.long_desc["fr-FR"] = L"Renvoie le niveau le plus élevé que possède un élément dans la hiérarchie de consolidation de la dimension indiquée.";
        fd.long_desc["cs-CZ"] = L"Vrátí počet rodičovských úrovní v dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension dont le niveau de consolidation doit être indiqué.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloPing";
        fd.c_name = "palo_ping";
        
        fd.xl_doc.xl_name = "PALO.PING";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"";
        fd.short_desc["cs-CZ"] = L"";
        fd.long_desc["en"] = L"";
        fd.long_desc["cs-CZ"] = L"";
        {
          ArgumentDocumentation a;
    
          a.name = "Server";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server";
        a.short_desc["de-DE"] = L"Server";
        a.short_desc["fr-FR"] = L"Serveur";
        a.short_desc["cs-CZ"] = L"Server";
        a.long_desc["en"] = L"Server";
        a.long_desc["de-DE"] = L"Server";
        a.long_desc["fr-FR"] = L"Serveur";
        a.long_desc["cs-CZ"] = L"Server";
      
          fd.arg_pool["Server"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloRootListDatabases";
        fd.c_name = "palo_root_list_databases";
        
        fd.xl_doc.xl_name = "PALO.ROOT_LIST_DATABASES";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the list of all databases of a server.";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Datenbanken eines Servers";
        fd.short_desc["fr-FR"] = L"Donne une liste avec toutes les bases de données du serveur spécifié.";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech databází na serveru.";
        fd.long_desc["en"] = L"Returns the list of all databases of a server.";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Datenbanken eines Servers";
        fd.long_desc["fr-FR"] = L"Donne une liste avec toutes les bases de données du serveur spécifié.";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech databází na serveru.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server";
        a.short_desc["de-DE"] = L"Server";
        a.short_desc["fr-FR"] = L"Serveur";
        a.short_desc["cs-CZ"] = L"Server";
        a.long_desc["en"] = L"Server";
        a.long_desc["de-DE"] = L"Server";
        a.long_desc["fr-FR"] = L"Serveur";
        a.long_desc["cs-CZ"] = L"Server";
      
          fd.arg_pool["Server"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ListSystem";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"List system";
        a.short_desc["de-DE"] = L"Zeige DB System";
        a.short_desc["fr-FR"] = L"Afficher les bases de données système";
        a.short_desc["cs-CZ"] = L"Vypsat také systémové databáze";
        a.long_desc["en"] = L"List system databases too (TRUE/FALSE).";
        a.long_desc["de-DE"] = L"Zeige auch Systemdatenbanken (WAHR/FALSCH)";
        a.long_desc["fr-FR"] = L"Affiche aussi la base de données système (VRAI/FAUX)";
        a.long_desc["cs-CZ"] = L"Vypsat také systémové databáze (PRAVDA/NEPRAVDA).";
      
          fd.arg_pool["ListSystem"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ListUserInfo";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"List Userinfo";
        a.short_desc["de-DE"] = L"Zeige auch Benutzerdatenbanken";
        a.short_desc["fr-FR"] = L"Afficher les bases de données utilisateur";
        a.short_desc["cs-CZ"] = L"Vypsat také databáze s informacemi o uživateli";
        a.long_desc["en"] = L"List userinfo databases too (TRUE/FALSE).";
        a.long_desc["de-DE"] = L"Zeige auch Benutzerdatenbanken (WAHR/FALSCH)";
        a.long_desc["fr-FR"] = L"Affichage également le base de données des utilisateurs(vrai/faux).";
        a.long_desc["cs-CZ"] = L"Vypsat také databáze s informacemi o uživateli (PRAVDA/NEPRAVDA).";
      
          fd.arg_pool["ListUserInfo"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server");
          p.arg_keys.push_back("ListSystem");
          p.arg_keys.push_back("ListUserInfo");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseListCubes";
        fd.c_name = "palo_database_list_cubes";
        
        fd.xl_doc.xl_name = "PALO.DATABASE_LIST_CUBES";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the list of all cubes of a database.";
        fd.short_desc["de-DE"] = L"Listet alle Würfel einer Datenbank auf ";
        fd.short_desc["fr-FR"] = L"La fonction établit, dans une plage que vous aurez prédéfinie, une liste des cubes d’une base de données. ";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech kostek na serveru.";
        fd.long_desc["en"] = L"Returns the list of all cubes of a server";
        fd.long_desc["de-DE"] = L"Listet alle Würfel einer Datenbank auf ";
        fd.long_desc["fr-FR"] = L"La fonction établit, dans une plage que vous aurez prédéfinie, une liste des cubes d’une base de données. ";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech kostek na serveru.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"Optional: type of the cubes (0=normal, 1=system, 2=attribute, 3=userinfo, 4=gpu)";
        a.long_desc["de-DE"] = L"Optional: Typ der Würfel (0=Normal, 1=System, 2=Attribut, 3=Benutzer, 4=GPU) ";
        a.long_desc["fr-FR"] = L"Optional: Type des cubes (0=normal, 1=system, 2=attribut, 3=userinfo, 4=gpu)";
        a.long_desc["cs-CZ"] = L"Volitelné: typ kostek (0=normalní, 1=systémová, 2=atribuční, 3=uživatelská, 4=gpu)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Type");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseListDimensions";
        fd.c_name = "palo_database_list_dimensions";
        
        fd.xl_doc.xl_name = "PALO.DATABASE_LIST_DIMENSIONS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all dimensions of a database.";
        fd.short_desc["de-DE"] = L"Listet alle Dimensionen einer Datenbank auf";
        fd.short_desc["fr-FR"] = L"La fonction établit, dans une plage que vous aurez prédéfinie, une liste des dimensions d’une base de données. ";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech dimenzí určené databáze.";
        fd.long_desc["en"] = L"Returns a list with all dimensions of a database";
        fd.long_desc["de-DE"] = L"Listet alle Dimensionen einer Datenbank auf";
        fd.long_desc["fr-FR"] = L"La fonction établit, dans une plage que vous aurez prédéfinie, une liste des dimensions d’une base de données. ";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech dimenzí určené databáze.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"Optional: type of the dimensions (0=normal, 1=system, 2=attribute, 3=userinfo)";
        a.long_desc["de-DE"] = L"Optional: Typ der Dimensionen (0=Normal, 1=System, 2=Attribut, 3=Benutzer)";
        a.long_desc["fr-FR"] = L"Optional: Type des dimensions (0=normal, 1=system, 2=attribut, 3=userinfo, 4=gpu)";
        a.long_desc["cs-CZ"] = L"Volitelné: typ dimenzí (0=normalní, 1=systemová, 2=atribuční, 3=uživatelská)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Type");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloCubeListDimensions";
        fd.c_name = "palo_cube_list_dimensions";
        
        fd.xl_doc.xl_name = "PALO.CUBE_LIST_DIMENSIONS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all dimensions of a cube";
        fd.short_desc["de-DE"] = L"Listet alle Dimensionen eines Würfels auf";
        fd.short_desc["fr-FR"] = L"Donne une liste de toutes les dimensions d’un cube déterminé.";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech dimenzí kostky.";
        fd.long_desc["en"] = L"Returns a list with all dimensions of a cube.";
        fd.long_desc["de-DE"] = L"Listet alle Dimensionen eines Würfels auf";
        fd.long_desc["fr-FR"] = L"Donne une liste de toutes les dimensions d’un cube déterminé.";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech dimenzí určené kostky.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Nom du cube dont les dimensions doivent être renvoyées.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionListCubes";
        fd.c_name = "palo_dimension_list_cubes";
        
        fd.xl_doc.xl_name = "PALO.DIMENSION_LIST_CUBES";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list of all cubes which contain a specified dimension.";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Würfeln, die die angegebene Dimension enthalten ";
        fd.short_desc["fr-FR"] = L"La fonction établit la liste de tous les cubes utilisés par des dimensions définies. ";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech kostek, které obsahují určenou dimenzil.";
        fd.long_desc["en"] = L"Returns a list of all cubes which contain a specified dimension";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Würfeln, die die angegebene Dimensionenthalten ";
        fd.long_desc["fr-FR"] = L"La fonction établit la liste de tous les cubes utilisés par des dimensions définies. ";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech kostek, které obsahují určenou dimenzi.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionListElements";
        fd.c_name = "palo_dimension_list_elements";
        
        fd.xl_doc.xl_name = "PALO.DIMENSION_LIST_ELEMENTS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the list with all elements of a specified dimension";
        fd.short_desc["de-DE"] = L"der angegebenen Dimension enthalten sind";
        fd.short_desc["fr-FR"] = L"Établit, dans une plage que vous aurez prédéfinie, la liste des éléments contenus dans une dimension. ";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech prvků z určené dimenze";
        fd.long_desc["en"] = L"Returns the list with all elements of a specified dimension";
        fd.long_desc["de-DE"] = L"der angegebenen Dimension enthalten sind";
        fd.long_desc["fr-FR"] = L"Établit, dans une plage que vous aurez prédéfinie, la liste des éléments contenus dans une dimension. ";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech prvků z určené dimenze";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient les éléments à agencer. ";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Filter";
        a.short_desc["de-DE"] = L"Filter";
        a.short_desc["fr-FR"] = L"Filtre";
        a.short_desc["cs-CZ"] = L"Filtr";
        a.long_desc["en"] = L"Removes empty elements";
        a.long_desc["de-DE"] = L"Entfernt leere Elemente.";
        a.long_desc["fr-FR"] = L"Supprime les éléments vides. ";
        a.long_desc["cs-CZ"] = L"Odstraní prázdné prvky.";
      
          fd.arg_pool["Filter"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Filter");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionListElements2";
        fd.c_name = "palo_dimension_list_elements2";
        fd.short_desc["en"] = L"Returns the list of all elements for the specified dimension";
        fd.short_desc["de-DE"] = L"Gibt eine Liste mit allen  Elementen der angegebenen  Dimension zurück";
        fd.short_desc["fr-FR"] = L"RRetourne une liste avec toutes les éléments de la dimension specifiée.";
        fd.short_desc["cs-CZ"] = L"Returns the list of all elements for the specified dimension";
        fd.long_desc["en"] = L"Returns the list of all elements for the specified dimension";
        fd.long_desc["de-DE"] = L"Gibt eine Liste mit allen  Elementen der angegebenen  Dimension zurück";
        fd.long_desc["fr-FR"] = L"Retourne une liste avec toutes les éléments de la dimension specifiée.";
        fd.long_desc["cs-CZ"] = L"Returns the list of all elements for the specified dimension";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Filter";
        a.short_desc["de-DE"] = L"Filter";
        a.short_desc["fr-FR"] = L"Filtre";
        a.short_desc["cs-CZ"] = L"Filtr";
        a.long_desc["en"] = L"Removes empty elements";
        a.long_desc["de-DE"] = L"Entfernt leere Elemente.";
        a.long_desc["fr-FR"] = L"Supprime les éléments vides.";
        a.long_desc["cs-CZ"] = L"Removes empty elements";
      
          fd.arg_pool["Filter"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Filter");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListConsolidationElements";
        fd.c_name = "palo_element_list_consolidation_elements";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_CONSOLIDATION_ELEMENTS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all child elements of a consolidated element";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.short_desc["fr-FR"] = L"Retourne une liste avec tous les éléments enfants d'un élément consolidé.";
        fd.short_desc["cs-CZ"] = L"Returns a list with all child elements of a consolidated element";
        fd.long_desc["en"] = L"Returns a list with all child elements of a consolidated element";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.long_desc["fr-FR"] = L"Retourne une liste avec tous les éléments enfants d'un élément consolidé.";
        fd.long_desc["cs-CZ"] = L"Returns a list with all child elements of a consolidated element";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the consolidation element.";
        a.long_desc["de-DE"] = L"Name des konsolidierten Elements";
        a.long_desc["fr-FR"] = L"Name of the consolidation element";
        a.long_desc["cs-CZ"] = L"Name of the consolidation element.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListConsolidationElements";
        fd.c_name = "palo_element_list_children";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_CHILDREN";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all child elements of a consolidated element";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.short_desc["fr-FR"] = L"Donne une liste de tous les éléments consolidés d’un élément défini.";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech dětí konsolidovaného prvku.";
        fd.long_desc["en"] = L"Returns a list with all child elements of a consolidated element";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.long_desc["fr-FR"] = L"Donne une liste de tous les éléments consolidés d’un élément défini.";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech dětí konsolidovaného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the Dimension which contains the specified element.";
        a.long_desc["de-DE"] = L"Name der Dimension, die das bestimmte Element enthält";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément indiqué.";
        a.long_desc["cs-CZ"] = L"Název dimenze, která obsahuje určený prvek.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the consolidated element.";
        a.long_desc["de-DE"] = L"Name des konsolidierten Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément consolidé.";
        a.long_desc["cs-CZ"] = L"Název konsolidovaného prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListParents";
        fd.c_name = "palo_element_list_parents";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_PARENTS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all parents of an element.";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Elternelementen eines Elements";
        fd.short_desc["fr-FR"] = L"Retourne une liste de tous les parents d'un élément";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam všech rodičů určeného prvku.";
        fd.long_desc["en"] = L"Returns a list with all parents of an element.";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Elternelementen eines Elements";
        fd.long_desc["fr-FR"] = L"Retourne une liste de tous les parents d'un élément";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech rodičů určeného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la Dimension";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListSiblings";
        fd.c_name = "palo_element_list_siblings";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_SIBLINGS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a list with all elements which are on the same hierarchy-level as the specified element";
        fd.short_desc["de-DE"] = L"Name des Elementes";
        fd.short_desc["fr-FR"] = L"Retourne une liste de tous les éléments qui sont sur le même niveau hiérarchique que l’élément spécifié";
        fd.short_desc["cs-CZ"] = L"Vrátí seznam prvků, které jsou na stejné úrovni hierarchie jako určený prvek)";
        fd.long_desc["en"] = L"Returns a list with all elements which are on the same hierarchy-level as the specified element.";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Elementen, die mit dem anzugebenden Element auf der gleichen Ebene liegen";
        fd.long_desc["fr-FR"] = L"Retourne une liste de tous les éléments qui sont sur le même niveau hiérarchique que l’élément spécifié";
        fd.long_desc["cs-CZ"] = L"Vrátí seznam všech dětí konsolidovaného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la Dimension";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element.";
        a.long_desc["de-DE"] = L"Name des Elementes";
        a.long_desc["fr-FR"] = L"Nom de l’élément";
        a.long_desc["cs-CZ"] = L"Název prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementDelete";
        fd.c_name = "palo_edelete";
        
        fd.xl_doc.xl_name = "PALO.EDELETE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Deletes the specified element";
        fd.short_desc["de-DE"] = L"Löscht das beschriebene Element";
        fd.short_desc["fr-FR"] = L"Supprime l'élément spécifié.";
        fd.short_desc["cs-CZ"] = L"Smaže určený prvek";
        fd.long_desc["en"] = L"Deletes the specified element";
        fd.long_desc["de-DE"] = L"Löscht das beschriebene Element";
        fd.long_desc["fr-FR"] = L"Supprime l’élément indiqué.";
        fd.long_desc["cs-CZ"] = L"Smaže určený prvek";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension which contains the element that should be deleted.";
        a.long_desc["de-DE"] = L"Name der Dimension, die das zu löschende Element enthält";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à supprimer.";
        a.long_desc["cs-CZ"] = L"Název dimenze obsahující prvek, který chcete odstranit.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the element which shold be deleted.";
        a.long_desc["de-DE"] = L"Name des Elementes, dass gelöscht werden soll.";
        a.long_desc["fr-FR"] = L"Nom de l’élément qui doit être supprimé.";
        a.long_desc["cs-CZ"] = L"Název prvku určeného ke smazání.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementDeleteBulk";
        fd.c_name = "palo_edelete_bulk";
        fd.short_desc["en"] = L"Deletes the specified element";
        fd.short_desc["de-DE"] = L"Löscht das beschriebene Element";
        fd.short_desc["fr-FR"] = L"Supprime l'élément spécifié.";
        fd.short_desc["cs-CZ"] = L"Deletes the specified element";
        fd.long_desc["en"] = L"Deletes the specified element.";
        fd.long_desc["de-DE"] = L"Löscht das beschriebene Element";
        fd.long_desc["fr-FR"] = L"Supprime l'élément spécifié.";
        fd.long_desc["cs-CZ"] = L"Deletes the specified element.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension which contains the element that should be deleted.";
        a.long_desc["de-DE"] = L"Name der Dimension, die das zu löschende Element enthält";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l'élément qui doit être supprimé.";
        a.long_desc["cs-CZ"] = L"Name of the dimension which contains the element that should be deleted.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ElementArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Array of element names which should be deleted.";
        a.long_desc["de-DE"] = L"Ein Array mit Elementnamen, die gelöscht werden sollen";
        a.long_desc["fr-FR"] = L"Array avec les noms d'éléments qui devraient être supprimés.";
        a.long_desc["cs-CZ"] = L"Array of element names which should be deleted.";
      
          fd.arg_pool["ElementArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Empty String";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("ElementArray");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementAdd";
        fd.c_name = "palo_eadd";
        
        fd.xl_doc.xl_name = "PALO.EADD";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Adds the specified element to the database.";
        fd.short_desc["de-DE"] = L"Fügt das beschriebene Element zur Datenbank hinzu";
        fd.short_desc["fr-FR"] = L"Ajoute l’élément de dimension indiqué ou les structures à la base de données.";
        fd.short_desc["cs-CZ"] = L"Přidá určený prvek dimenze do databáze.";
        fd.long_desc["en"] = L"Adds the specified element to the database.";
        fd.long_desc["de-DE"] = L"Fügt das beschriebene Element zur Datenbank hinzu";
        fd.long_desc["fr-FR"] = L"Ajoute l’élément de dimension indiqué ou les structures à la base de données.";
        fd.long_desc["cs-CZ"] = L"Přidá určený prvek dimenze do databáze.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension dans laquelle un élément doit être ajouté.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"Type of the new element (use \'N\' for numeric, \'C\' for consolidation or \'S\' for string element)";
        a.long_desc["de-DE"] = L"Typ des einzufügenden Elements (anzugeben ist: 'N' für numerisch, 'C' für konsolidiert oder 'S' für ein Text-Element)";
        a.long_desc["fr-FR"] = L"Type de l’élément à ajouter (indiquez: \'N\' pour numérique, \'C\' pour consolidé ou \'S\' pour un élément string)";
        a.long_desc["cs-CZ"] = L"Typ nového prvku (N - numerický, C - konsolidovaný, S - textový)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the new element.";
        a.long_desc["de-DE"] = L"Name des Elementes, dass aktualisiert werden soll";
        a.long_desc["fr-FR"] = L"Nom de l’élément qui doit être ajouté.";
        a.long_desc["cs-CZ"] = L"Název nového prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Parent Element";
        a.short_desc["de-DE"] = L"Elternelement";
        a.short_desc["fr-FR"] = L"Élément parent";
        a.short_desc["cs-CZ"] = L"Rodičovského prvku";
        a.long_desc["en"] = L"Name of the parent element (use an empty string, if the new element should not be a child element).";
        a.long_desc["de-DE"] = L"Name des Elternelements. Leer lassen wenn es ein Basiselement ist";
        a.long_desc["fr-FR"] = L"Nom de l’élément consolidé ou d’un String vide si c’est un élément de base.";
        a.long_desc["cs-CZ"] = L"Název rodičovského prvku (použijte prázdný řetězec, pokud nový prvek by neměl být prvek dítěte).";
      
          fd.arg_pool["Parent Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Weight";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Weight";
        a.short_desc["de-DE"] = L"Konsolidierungsfaktor";
        a.short_desc["fr-FR"] = L"Facteur de consolidation";
        a.short_desc["cs-CZ"] = L"Váha nového prvku";
        a.long_desc["en"] = L"Consolidation factor of the new element.";
        a.long_desc["de-DE"] = L"Konsolidierungsfaktor des einzufügenden Elements";
        a.long_desc["fr-FR"] = L"Facteur de consolidation de l’élément à ajouter.";
        a.long_desc["cs-CZ"] = L"Váha nového prvku";
      
          fd.arg_pool["Weight"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Clear";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Clear";
        a.short_desc["de-DE"] = L"Löschen";
        a.short_desc["fr-FR"] = L"Effacer";
        a.short_desc["cs-CZ"] = L"Odstranit";
        a.long_desc["en"] = L"TRUE deletes the existing elements in the Dimension before the import, FALSE adds the new element without clearing any elements before.";
        a.long_desc["de-DE"] = L"WAHR entfernt vor dem Import alle vorhandenen Elemente der Dimension, FALSCH  fügt das Element hinzu ohne irgendwelche Elemente vorher zu löschen";
        a.long_desc["fr-FR"] = L"Supprime avant l’import tous les éléments présents de la dimension si la requête (Vrai/Faux) est sur VRAI, autrement un élément est ajouté sans que la dimension soit auparavant supprimée.";
        a.long_desc["cs-CZ"] = L"Je-li hodnota tohoto argumentu PRAVDA, bude před přidáním nového prvku dimenze vyčištěná. V opačném případě bude prvek přidán bez vyčištění dimenze.";
      
          fd.arg_pool["Clear"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Type");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Parent Element");
          p.arg_keys.push_back("Weight");
          p.arg_keys.push_back("Clear");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementUpdate";
        fd.c_name = "palo_eupdate";
        
        fd.xl_doc.xl_name = "PALO.EUPDATE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Updates an existing element";
        fd.short_desc["de-DE"] = L"Aktualisiert ein existierendes Element";
        fd.short_desc["fr-FR"] = L"Fonction pour actualiser d'un élément existant";
        fd.short_desc["cs-CZ"] = L"Aktualizuje existující prvek";
        fd.long_desc["en"] = L"Updates an existing element";
        fd.long_desc["de-DE"] = L"Aktualisiert ein existierendes Element";
        fd.long_desc["fr-FR"] = L"Fonction pour actualiser d'un élément existant";
        fd.long_desc["cs-CZ"] = L"Aktualizuje existující prvek";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Name of the new element.";
        a.long_desc["de-DE"] = L"Name des Elementes, dass aktualisiert werden soll";
        a.long_desc["fr-FR"] = L"Nom de l'élément qui doit être actualisé";
        a.long_desc["cs-CZ"] = L"Název nového prvku";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"Type of the new element (use \'N\' for numeric, \'C\' for consolidation or \'S\' for string element)";
        a.long_desc["de-DE"] = L"Typ des einzufügenden Elements (anzugeben ist: 'N' für numerisch, 'C' für konsolidiert oder 'S' für ein Text-Element)";
        a.long_desc["fr-FR"] = L"Type de l'élément (anzugeben ist: \'N\' für numerisch, \'C\' für konsolidiert oder \'S\' für ein String element)";
        a.long_desc["cs-CZ"] = L"Typ prvku ('N' pro numericlá, 'C' pro konsolidovaný or 'S' pro textový)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Children";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"C-Elements";
        a.short_desc["de-DE"] = L"C-Elemente";
        a.short_desc["fr-FR"] = L"Éléments consolidés.";
        a.short_desc["cs-CZ"] = L"Konsolidovaný prvky";
        a.long_desc["en"] = L"Array with consolidated elements. Leave blank if you just want to change the type of an element.";
        a.long_desc["de-DE"] = L"Ein Array bestehend aus konsolidierten Elementen. Einfach leer lassen um nur den Typ des Elementes zu ändern";
        a.long_desc["fr-FR"] = L"Une matrice des  éléments consolidés. Ce paramètre sera laissé vide pour changer seulement le type.";
        a.long_desc["cs-CZ"] = L"Pole s konsolidovanými prvky. Ponechte prázdné, pokud chcete pouze změnit typ prvku.";
      
          fd.arg_pool["Children"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Append";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Append";
        a.short_desc["de-DE"] = L"Hinzufügen";
        a.short_desc["fr-FR"] = L"Ajouter";
        a.short_desc["cs-CZ"] = L"připojit dítě";
        a.long_desc["en"] = L"False/0 = replace existing child elements with the specified element list, True/1 = add elements to list children, 2 = delete elements from list of children";
        a.long_desc["de-DE"] = L"FALSCH/0 = ersetze die Liste von Kind-Elementen mit der angegebenen Element-Liste, WAHR/1 = füge die Elemente als neue Kidner hinzu, 2 = enterferne die Elemente aus der Liste der Kind-Elemente";
        a.long_desc["fr-FR"] = L"Ajouter les enfants";
        a.long_desc["cs-CZ"] = L"připojit dítě";
      
          fd.arg_pool["Append"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Type");
          p.arg_keys.push_back("Children");
          p.arg_keys.push_back("Append");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementRename";
        fd.c_name = "palo_erename";
        
        fd.xl_doc.xl_name = "PALO.ERENAME";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Renames the specified element";
        fd.short_desc["de-DE"] = L"Benennt das angegebene Element um";
        fd.short_desc["fr-FR"] = L"Renomme l’élément indiqué.";
        fd.short_desc["cs-CZ"] = L"Přejmenuje určený prvek";
        fd.long_desc["en"] = L"Renames the specified element";
        fd.long_desc["de-DE"] = L"Benennt das angegebene Element um";
        fd.long_desc["fr-FR"] = L"Renomme l’élément indiqué.";
        fd.long_desc["cs-CZ"] = L"Přejmenuje určený prvek";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension dans laquelle l’élément défini doit être renommé.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Old Name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Old Name";
        a.short_desc["de-DE"] = L"Alter Name";
        a.short_desc["fr-FR"] = L"L'ancien nom";
        a.short_desc["cs-CZ"] = L"Starý název";
        a.long_desc["en"] = L"Name of the element, whose name should be changed.";
        a.long_desc["de-DE"] = L"Name des Elementes, dessen Name geändert werden soll";
        a.long_desc["fr-FR"] = L"Ancien nom";
        a.long_desc["cs-CZ"] = L"Název prvku, jehož název chcete změnit.";
      
          fd.arg_pool["Old Name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "New Name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"New Name";
        a.short_desc["de-DE"] = L"Neuer Name";
        a.short_desc["fr-FR"] = L"Nouveau nom";
        a.short_desc["cs-CZ"] = L"Nový název";
        a.long_desc["en"] = L"New Name";
        a.long_desc["de-DE"] = L"Neuer Name";
        a.long_desc["fr-FR"] = L"Nouveau nom";
        a.long_desc["cs-CZ"] = L"Nový název";
      
          fd.arg_pool["New Name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Old Name");
          p.arg_keys.push_back("New Name");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloLogSetdataError";
        fd.c_name = "palo_setdata_error";
        
        fd.xl_doc.xl_name = "PALO.SETDATA_ERROR";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.short_desc["de-DE"] = L"Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.short_desc["fr-FR"] = L"Écrit les records qui renvoie une erreur lors de la boucle d'importation, dans un fichier d'erreur.";
        fd.short_desc["cs-CZ"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["en"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["de-DE"] = L"Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.long_desc["fr-FR"] = L"Écrit les enregistrements, qui renvoie une erreur lors de la boucle de l'importation, dans un fichier d'erreur.";
        fd.long_desc["cs-CZ"] = L"Writes the records, which returns error during the import loop, in an error file.";
        {
          ArgumentDocumentation a;
    
          a.name = "Error";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Error";
        a.short_desc["de-DE"] = L"Fehler";
        a.short_desc["fr-FR"] = L"Erreur";
        a.short_desc["cs-CZ"] = L"Error";
        a.long_desc["en"] = L"Cell that contains the error, so the cell with the Palo.Setdata function.";
        a.long_desc["de-DE"] = L"Die Zelle, in der der Fehler entsteht, also die Zelle mit der Palo.Setdata-Funktion";
        a.long_desc["fr-FR"] = L"La cellule dans laquelle il devient l'erreur, à savoir la cellule avec la fonction Palo.Setdata.";
        a.long_desc["cs-CZ"] = L"Cell that contains the error, so the cell with the Palo.Setdata function.";
      
          fd.arg_pool["Error"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Path";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Path";
        a.short_desc["de-DE"] = L"Pfad";
        a.short_desc["fr-FR"] = L"Chemin";
        a.short_desc["cs-CZ"] = L"Path";
        a.long_desc["en"] = L"Path and name of the errorfile";
        a.long_desc["de-DE"] = L"Pfadangabe und Name der Fehlerdatei";
        a.long_desc["fr-FR"] = L"Chemin et nom de fichier d'erreurs.";
        a.long_desc["cs-CZ"] = L"Path and name of the errorfile";
      
          fd.arg_pool["Path"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Value";
        a.long_desc["en"] = L"Erroneous value";
        a.long_desc["de-DE"] = L"Fehlerhafter Wert.";
        a.long_desc["fr-FR"] = L"Valeur incorrecte";
        a.long_desc["cs-CZ"] = L"Erroneous value";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Le nom du cube";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans l'ordre que dans le cube.";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Error");
          p.arg_keys.push_back("Path");
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloLogSetdataError";
        fd.c_name = "palo_error_log";
        
        fd.xl_doc.xl_name = "PALO.ERROR_LOG";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.short_desc["de-DE"] = L"Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.short_desc["fr-FR"] = L"Écrit les enregistrements d’un fichier import qui ne correspondent pas aux spécifications de l’import dans un fichier erreur.";
        fd.short_desc["cs-CZ"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["en"] = L"Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["de-DE"] = L"Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.long_desc["fr-FR"] = L"Écrit les enregistrements d’un fichier import qui ne correspondent pas aux spécifications de l’import dans un fichier erreur.";
        fd.long_desc["cs-CZ"] = L"Writes the records, which returns error during the import loop, in an error file.";
        {
          ArgumentDocumentation a;
    
          a.name = "Error";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Error";
        a.short_desc["de-DE"] = L"Fehler";
        a.short_desc["fr-FR"] = L"Erreur";
        a.short_desc["cs-CZ"] = L"Error";
        a.long_desc["en"] = L"Cell that contains the error, so the cell with the Palo.Setdata function";
        a.long_desc["de-DE"] = L"Die Zelle, in der der Fehler entsteht, also die Zelle mit der Palo.Setdata-Funktion";
        a.long_desc["fr-FR"] = L"La cellule contenant l’erreur, soit la cellule avec la fonction-\"Palo.Setdata\"";
        a.long_desc["cs-CZ"] = L"Cell that contains the error, so the cell with the Palo.Setdata function";
      
          fd.arg_pool["Error"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Path";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Path";
        a.short_desc["de-DE"] = L"Pfad";
        a.short_desc["fr-FR"] = L"Chemin";
        a.short_desc["cs-CZ"] = L"Path";
        a.long_desc["en"] = L"Path and name of the errorfile.";
        a.long_desc["de-DE"] = L"Pfad und Name der Fehlerdatei.";
        a.long_desc["fr-FR"] = L"Le fichier avec le chemin dans lequel les erreurs sont enregistrés.";
        a.long_desc["cs-CZ"] = L"Path and name of the errorfile.";
      
          fd.arg_pool["Path"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Value";
        a.short_desc["de-DE"] = L"Wert";
        a.short_desc["fr-FR"] = L"Valeur";
        a.short_desc["cs-CZ"] = L"Value";
        a.long_desc["en"] = L"Erroneous value";
        a.long_desc["de-DE"] = L"Fehlerhafter Wert.";
        a.long_desc["fr-FR"] = L"Valeur erronée.";
        a.long_desc["cs-CZ"] = L"Erroneous value";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Error");
          p.arg_keys.push_back("Path");
          p.arg_keys.push_back("Value");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloServerSubset";
        fd.c_name = "palo_server_subset";
        
        fd.xl_doc.xl_name = "PALO.SERVER_SUBSET";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension.";
        fd.short_desc["cs-CZ"] = L"Vrátí subset prvků dimenze.";
        fd.long_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí subset prvků dimenze.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données.";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Global";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Global";
        a.short_desc["de-DE"] = L"Global";
        a.short_desc["fr-FR"] = L"Global";
        a.short_desc["cs-CZ"] = L"Globální";
        a.long_desc["en"] = L"TRUE shows a global subset. FALSE executes a local subset.";
        a.long_desc["de-DE"] = L"WAHR zeigt ein globales Subset an. FALSCH zeigt ein lokales Subset an";
        a.long_desc["fr-FR"] = L"global";
        a.long_desc["cs-CZ"] = L"Hodnota PRAVDA zobrazí globální subset. Hodnota NEPRAVDA vykoná lokální subset.";
      
          fd.arg_pool["Global"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Subsetname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Subsetname";
        a.short_desc["de-DE"] = L"Subsetname";
        a.short_desc["fr-FR"] = L"Le nom de sous-ensemble";
        a.short_desc["cs-CZ"] = L"Název subsetu";
        a.long_desc["en"] = L"Name of the Subset.";
        a.long_desc["de-DE"] = L"Name des Subset";
        a.long_desc["fr-FR"] = L"Nom du sous-ensemble.";
        a.long_desc["cs-CZ"] = L"Název subsetu";
      
          fd.arg_pool["Subsetname"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Global");
          p.arg_keys.push_back("Subsetname");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloServerSubset";
        fd.c_name = "palo_serversubset";
        
        fd.xl_doc.xl_name = "PALO.SERVERSUBSET";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = L"Retourne un sous-ensemble d'éléments.";
        fd.short_desc["cs-CZ"] = L"Returns a subset of Dimensionelements.";
        fd.long_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = L"Retourne un sous-ensemble d'éléments.";
        fd.long_desc["cs-CZ"] = L"Returns a subset of Dimensionelements.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Global";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Global";
        a.short_desc["de-DE"] = L"Global";
        a.short_desc["fr-FR"] = L"Global";
        a.short_desc["cs-CZ"] = L"Global";
        a.long_desc["en"] = L"TRUE shows a global subset. FALSE executes a local subset.";
        a.long_desc["de-DE"] = L"WAHR zeigt ein globales Subset an. FALSCH zeigt ein lokales Subset an";
        a.long_desc["fr-FR"] = L"Avec VRAI est créé un sous-ensemble global, avec FAUX est créé un sous-ensemble local.";
        a.long_desc["cs-CZ"] = L"TRUE shows a global subset. FALSE executes a local subset.";
      
          fd.arg_pool["Global"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Subsetname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Subsetname";
        a.short_desc["de-DE"] = L"Subsetname";
        a.short_desc["fr-FR"] = L"Le nom de sous-ensemble";
        a.short_desc["cs-CZ"] = L"Subsetname";
        a.long_desc["en"] = L"Name of the Subset.";
        a.long_desc["de-DE"] = L"Name des Subset";
        a.long_desc["fr-FR"] = L"Name of the Subset";
        a.long_desc["cs-CZ"] = L"Name of the Subset.";
      
          fd.arg_pool["Subsetname"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Global");
          p.arg_keys.push_back("Subsetname");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubset";
        fd.c_name = "palo_subset";
        
        fd.xl_doc.xl_name = "PALO.SUBSET";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension.";
        fd.short_desc["cs-CZ"] = L"Vrátí subset prvků dimenze";
        fd.long_desc["en"] = L"Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = L"Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí subset prvků dimenze";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient les éléments à indiquer.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Indent";
        a.short_desc["de-DE"] = L"Einrückung";
        a.short_desc["fr-FR"] = L"Indentation";
        a.short_desc["cs-CZ"] = L"Odsazení";
        a.long_desc["en"] = L"Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = L"Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = L"Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
        a.long_desc["cs-CZ"] = L"Zádání \"1\", \"2\" nebo \"3\" určují typ odsazení. Pokud bude argument prázdný, pohled bude plochý.";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Alias";
        a.short_desc["de-DE"] = L"Alias";
        a.short_desc["fr-FR"] = L"Alias";
        a.short_desc["cs-CZ"] = L"Aliasu";
        a.long_desc["en"] = L"Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = L"Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = L"Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
        a.long_desc["cs-CZ"] = L"Alternativní název prvku definovaného jako atribuce.";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Filter";
        a.short_desc["de-DE"] = L"Filter";
        a.short_desc["fr-FR"] = L"Filtre";
        a.short_desc["cs-CZ"] = L"Filtr";
        a.long_desc["en"] = L"Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = L"Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = L"Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou SORT";
        a.long_desc["cs-CZ"] = L"Filtr1,Filtr2,.... Filtr = Výsledek funkcí DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER nebo SORT.";
      
          fd.arg_pool["Filter"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Indent");
          p.arg_keys.push_back("Alias");
          p.arg_keys.push_back("Filter");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetX";
        fd.c_name = "palo_subsetx";
        
        fd.xl_doc.xl_name = "PALO.SUBSETX";
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns a subset of Dimensionelements if called from active sheet";
        fd.short_desc["de-DE"] = L"Gibt dann eine Teilmenge von Dimensionselementen zurück, wenn die Fkt. vom aktiven Blatt aufgerufen wird";
        fd.short_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension si est appelée depuis une feuille active.";
        fd.short_desc["cs-CZ"] = L"Returns a subset of Dimensionelements if called from active sheet";
        fd.long_desc["en"] = L"Returns a subset of Dimensionelements if called from active sheet";
        fd.long_desc["de-DE"] = L"Gibt dann eine Teilmenge von Dimensionselementen zurück, wenn die Fkt. vom aktiven Blatt aufgerufen wird";
        fd.long_desc["fr-FR"] = L"Renvoie un sous-ensemble d’éléments de dimension si est appelée depuis une feuille active.";
        fd.long_desc["cs-CZ"] = L"Returns a subset of Dimensionelements if called from active sheet";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient les éléments À indiquer.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Indent";
        a.short_desc["de-DE"] = L"Einrückung";
        a.short_desc["fr-FR"] = L"Indentation";
        a.short_desc["cs-CZ"] = L"Odsazení";
        a.long_desc["en"] = L"Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = L"Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = L"Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
        a.long_desc["cs-CZ"] = L"Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Alias";
        a.short_desc["de-DE"] = L"Alias";
        a.short_desc["fr-FR"] = L"Alias";
        a.short_desc["cs-CZ"] = L"Aliasu";
        a.long_desc["en"] = L"Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = L"Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = L"Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
        a.long_desc["cs-CZ"] = L"Alternative name for an element that defined as an attribute";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Filter";
        a.short_desc["de-DE"] = L"Filter";
        a.short_desc["fr-FR"] = L"Filtre";
        a.short_desc["cs-CZ"] = L"Filtr";
        a.long_desc["en"] = L"Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = L"Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = L"Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou SORT.";
        a.long_desc["cs-CZ"] = L"Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
      
          fd.arg_pool["Filter"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Indent");
          p.arg_keys.push_back("Alias");
          p.arg_keys.push_back("Filter");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetSize";
        fd.c_name = "palo_subsetsize";
        
        fd.xl_doc.xl_name = "PALO.SUBSETSIZE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the length of a subset of Dimensionelements";
        fd.short_desc["de-DE"] = L"Gibt die Elementanzahl des Subsets zurück";
        fd.short_desc["fr-FR"] = L"Renvoie la longueur d’un extrait d’ensemble d’un élément de dimension.";
        fd.short_desc["cs-CZ"] = L"Vrátí délku subsetu prvků dimenze";
        fd.long_desc["en"] = L"Returns the length of a subset of Dimensionelements";
        fd.long_desc["de-DE"] = L"Gibt die Elementanzahl des Subsets zurück";
        fd.long_desc["fr-FR"] = L"Renvoie la longueur d’un extrait d’ensemble d’un élément de dimension.";
        fd.long_desc["cs-CZ"] = L"Vrátí délku subsetu prvků dimenze";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui contient l’élément à indiquer.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Indent";
        a.short_desc["de-DE"] = L"Einrückung";
        a.short_desc["fr-FR"] = L"Indentation";
        a.short_desc["cs-CZ"] = L"Odsazení";
        a.long_desc["en"] = L"Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = L"Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = L"Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
        a.long_desc["cs-CZ"] = L"Zádání \"1\", \"2\" nebo \"3\" určují typ odsazení. Pokud bude argument prázdný, pohled bude plochý.";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Alias";
        a.short_desc["de-DE"] = L"Alias";
        a.short_desc["fr-FR"] = L"Alias";
        a.short_desc["cs-CZ"] = L"Aliasu";
        a.long_desc["en"] = L"Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = L"Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = L"Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
        a.long_desc["cs-CZ"] = L"Alternativní název prvku definovaného jako atribuce.";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Filter";
        a.short_desc["de-DE"] = L"Filter";
        a.short_desc["fr-FR"] = L"Filtre";
        a.short_desc["cs-CZ"] = L"Filtr";
        a.long_desc["en"] = L"Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = L"Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = L"Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou. SORT.";
        a.long_desc["cs-CZ"] = L"Výsledek funkcí DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER nebo SORT.";
      
          fd.arg_pool["Filter"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Indent");
          p.arg_keys.push_back("Alias");
          p.arg_keys.push_back("Filter");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetBasicFilter";
        fd.c_name = "palo_picklist";
        
        fd.xl_doc.xl_name = "PALO.PICKLIST";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Adds elements to the subset which can not deleted by no way. Or it can be defined elements as a pre-selection.";
        fd.short_desc["de-DE"] = L"Kann Elemente zum SubSet hinzufügen, die dann auf keinen Fall wieder entfernt werden. Oder es können Elemente als eine Vorauswahl definiert werden";
        fd.short_desc["fr-FR"] = L"Peut ajouter des éléments à un sous-ensemble qui ne peuvent en aucun cas être à nouveau supprimés. En outre, il est possible de définir par ces derniers une multitude d’éléments qui feront office de filtre.";
        fd.short_desc["cs-CZ"] = L"Adds elements to the subset which can not deleted by no way. Further more a bulk can be defined, that attend as a filter";
        fd.long_desc["en"] = L"Adds elements to the subset which can not deleted by no way. Or it can be defined elements as a pre-selection.";
        fd.long_desc["de-DE"] = L"Kann Elemente zum SubSet hinzufügen, die dann auf keinen Fall wieder entfernt werden. Oder es können Elemente als eine Vorauswahl definiert werden";
        fd.long_desc["fr-FR"] = L"Peut ajouter des éléments à un sous-ensemble qui ne peuvent en aucun cas être à nouveau supprimés. En outre, il est possible de définir par ces derniers une multitude d’éléments qui feront office de filtre.";
        fd.long_desc["cs-CZ"] = L"Adds elements to the subset which can not deleted by no way. Further more a bulk can be defined, that attend as a filter";
        {
          ArgumentDocumentation a;
    
          a.name = "definition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Definition";
        a.short_desc["de-DE"] = L"Definition";
        a.short_desc["fr-FR"] = L"Définition";
        a.short_desc["cs-CZ"] = L"Definice";
        a.long_desc["en"] = L"Creation of elements, which will be added to the subset";
        a.long_desc["de-DE"] = L"Definition der Elemente, die zum Subset hinzugefügt werden";
        a.long_desc["fr-FR"] = L"Définition des éléments qui sont ajoutés au sous-ensemble.";
        a.long_desc["cs-CZ"] = L"Vytvoření prvků, které budou přidány do subsetu.";
      
          fd.arg_pool["definition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"0/empty = Elements will be added at the beginning of the subset, 1 = Elements will be added at the end of the subset, 2 = Elements will be merged into the subset, 3 = Picklist-elements are the exclusive pre-selection for the subset";
        a.long_desc["de-DE"] = L"0/leer = Elemente werden am Anfang des Subsets hinzugefügt, 1 = Elemente werden am Ende Subsets hinzugefügt, 2 = Elemente werden in das Subset sortiert eingefügt, 3 = Elemente sind die exclusive Vorauswahl für das Subset";
        a.long_desc["fr-FR"] = L"Formes comme éléments seront ajoutés au sous-ensemble. 0/vide = éléments seront mis au début du sous-ensemble, 1 = éléments seront mis à la fin du sous-ensemble, 2 = éléments seront ajoutés en";
        a.long_desc["cs-CZ"] = L"Determines how the picklist-elements will be used. 0/empty = Elements will be added at the beginning of the subset, 1 = Elements will be added at the end of the subset, 2 = Elements will be merged into the subset, 3 = Picklist-elements are the exclusive pre-selection for the subset";
      
          fd.arg_pool["type"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("definition");
          p.arg_keys.push_back("type");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetTextFilter";
        fd.c_name = "palo_tfilter";
        
        fd.xl_doc.xl_name = "PALO.TFILTER";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Elements which match the specified string model will be shown, the rest will be removed. More than on filter criteria can be specified in an array.";
        fd.short_desc["de-DE"] = L"Elemente, deren Namen bestimmten Mustern entsprechen, werden beibehalten, der Rest wird aus der Anzeige entfernt. Mehrere Filterkriterien können in einem Array angegeben werden";
        fd.short_desc["fr-FR"] = L"Éléments dont les noms correspondent à des modèles définis, sont conservés. Le reste est supprimé de l’affichage. Plusieurs critères de filtre sont indiqués dans la matrice.";
        fd.short_desc["cs-CZ"] = L"ZObrazí prvky, které odpovídají určenému modelu řetězce; ostatní prvky budou odstraněny. V poli musí být určeno více než jedno kritérium.";
        fd.long_desc["en"] = L"Elements which match the specified string model will be shown, the rest will be removed. More than on filter criteria can be specified in an array.";
        fd.long_desc["de-DE"] = L"Elemente, deren Namen bestimmten Mustern entsprechen, werden beibehalten, der Rest wird aus der Anzeige entfernt. Mehrere Filterkriterien können in einem Array angegeben werden";
        fd.long_desc["fr-FR"] = L"Éléments dont les noms correspondent à des modèles définis, sont conservés. Le reste est supprimé de l’affichage. Plusieurs critères de filtre sont indiqués dans la matrice.";
        fd.long_desc["cs-CZ"] = L"Budou zobrazeny prvky, které odpovídají určenému řetězcovému modelu, ostatní prvky budou odstraněny. V poli musí být určeno více než jedno filtrovací kritérium.";
        {
          ArgumentDocumentation a;
    
          a.name = "regex";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Regex";
        a.short_desc["de-DE"] = L"Regex";
        a.short_desc["fr-FR"] = L"Regex";
        a.short_desc["cs-CZ"] = L"Regex";
        a.long_desc["en"] = L"DOS filter criteria. \"D*\" for example removes all elements which do not beginn with \"D\"";
        a.long_desc["de-DE"] = L"DOS Filterkriterien. \"D*\" bewirkt z.B. dass alle Elemente entfernt werden die nicht mit \"D\" beginnen.";
        a.long_desc["fr-FR"] = L"DOS critères de tri. Produit le fait que tous les éléments qui ne commencent pas avec \"D\" ou un \"k\", seront supprimés. Le point d’interrogation  (\?) produit l’inverse du signe de valeur générale (*).";
        a.long_desc["cs-CZ"] = L"Filtrovací kritéria DOS. Např. \"D*\" odstraní všechny prvky, které nezačínají na \"D\".";
      
          fd.arg_pool["regex"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "extended";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Extended";
        a.short_desc["de-DE"] = L"Erweitert";
        a.short_desc["fr-FR"] = L"Avancé";
        a.short_desc["cs-CZ"] = L"Rozřířené";
        a.long_desc["en"] = L"Extended filter criteria. \"X$\" for example removes all elements which do not end with an \"X\"";
        a.long_desc["de-DE"] = L"Erweiterte Filterkriterien. \"X$\" bewirkt z.B. dass alle Elemente entfernt werden, die nicht mit \"X\" enden";
        a.long_desc["fr-FR"] = L"Extended produit le fait que tous les éléments qui ne se terminent pas par \"X\" ou ne contiennent pas  \"s\" ou un \"d\", seront affichés.";
        a.long_desc["cs-CZ"] = L"Rozřířená filtrovací kritéria. Např. \"X$\" odstraní všechny prvky, které nekončí na \"X\".";
      
          fd.arg_pool["extended"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("regex");
          p.arg_keys.push_back("extended");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetSortingFilter";
        fd.c_name = "palo_sort";
        
        fd.xl_doc.xl_name = "PALO.SORT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Sort the elements of a subset in a given order. For example order of definition or hierarchical order.";
        fd.short_desc["de-DE"] = L"Sortiert die Elemente des SubSets in einer bestimmten Reihenfolge, z.B. in der Definitionsreihenfolge oder der hierarchischen Reihenfolge";
        fd.short_desc["fr-FR"] = L"Définit l'affichage des éléments du sous-ensemble, par exemple en ordre de définition ou en ordre hiérarchique.";
        fd.short_desc["cs-CZ"] = L"Třídí prvky subsetu v daném pořadí. Například v pořadí vytvoření nebo dle hierarchie.";
        fd.long_desc["en"] = L"Sort the elements of a subset in a given order. For example order of definition or hierarchical order";
        fd.long_desc["de-DE"] = L"Sortiert die Elemente des SubSets in einer bestimmten Reihenfolge, z.B. in der Definitionsreihenfolge oder der hierarchischen Reihenfolge";
        fd.long_desc["fr-FR"] = L"Définit l'affichage des éléments du sous-ensemble, par exemple en ordre de définition ou en ordre hiérarchique.";
        fd.long_desc["cs-CZ"] = L"Třídí prvky subsetu v daném pořadí. Například v pořadí vytvoření nebo dle hierarchie.";
        {
          ArgumentDocumentation a;
    
          a.name = "whole";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Whole";
        a.short_desc["de-DE"] = L"Gesamtheit";
        a.short_desc["fr-FR"] = L"Entier";
        a.short_desc["cs-CZ"] = L"Celek";
        a.long_desc["en"] = L"\"0\"/empty = Definition order - default \"1\" = Shows hierarchy with child elements of elements which were removed from the subset. \"2\" = Cuts the view at this position";
        a.long_desc["de-DE"] = L"\"0\"/leer = Definitionsreihenfolge  \"1\" = Hierarchieansicht mit Kindern von Elementen, die aus dem Subset entfernt wurden. \"2\" = Schneidet die Ansicht an diesen Stellen ab";
        a.long_desc["fr-FR"] = L"\"0\"/empty Montre les éléments en l'ordre de définition. \"1\" montre les enfants d’éléments qui ont été supprimés du sous-ensemble. \"2\" coupe la vue à ces endroits.";
        a.long_desc["cs-CZ"] = L"\"0\"/prázdný Pořadí dle vytvoření - výchozí \"1\" zobrazí hierarchii s prvky dětí prvků, které byly odstraněny ze subsetu. \"2\" \"Uřízne\" pohled na současné pozici.";
      
          fd.arg_pool["whole"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "criteria";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Criteria";
        a.short_desc["de-DE"] = L"Kriterium";
        a.short_desc["fr-FR"] = L"Critères ";
        a.short_desc["cs-CZ"] = L"Kritéerium";
        a.long_desc["en"] = L"Grade for 0/empty = Definition, 1 = Data, 2 = Text, 3 = Alias";
        a.long_desc["de-DE"] = L"Sortiere nach 0/leer = Definition, 1 = Daten, 2 = Text, 3 = Alias";
        a.long_desc["fr-FR"] = L"Trie selon 0/vide = Définition, 1 = Données, 2 = Texte, 3 = Alias";
        a.long_desc["cs-CZ"] = L"Grade for 0/empty = Definition, 1 = Data, 2 = Text, 3 = Alias";
      
          fd.arg_pool["criteria"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Attribute";
        a.short_desc["de-DE"] = L"Attribut";
        a.short_desc["fr-FR"] = L"Attribut";
        a.short_desc["cs-CZ"] = L"Atribut";
        a.long_desc["en"] = L"Sorts by attributes. This filter should not be used with \"Criteria\"";
        a.long_desc["de-DE"] = L"Sortiert nach den Attributen. Dieser Filter sollte nicht mit \"Criteria\" zusammen verwendet werden.";
        a.long_desc["fr-FR"] = L"Trie selon les termes qui ont été définis par des attributs. Ce filtre ne devrait pas être utilisé avec \"Criteria\".";
        a.long_desc["cs-CZ"] = L"Seřadí podle atribucí. Tento filtr by neměl být použitý současně s Kritérium.";
      
          fd.arg_pool["attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "type_limitation";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type limitation";
        a.short_desc["de-DE"] = L"Typbegrenzung";
        a.short_desc["fr-FR"] = L"Limitation de type";
        a.short_desc["cs-CZ"] = L"Typ omezení";
        a.long_desc["en"] = L"This function just works with Criteria and Whole together. 0/empty = no action, 1 = sorting of basic elements only, 2 = sort only consolidated elements";
        a.long_desc["de-DE"] = L"Funktioniert nur zusammen mit Criteria und Whole. 0/leer = keine Wirkung, 1 = sortiert nur die Basiselemente, 2 = sortiert nur die Konsolidierungen";
        a.long_desc["fr-FR"] = L"Fonctionne seulement avec Critère et Affichage. 0/vide = aucun effet, 1 = trie seulement les éléments de base, 2 = trie les consolidations.";
        a.long_desc["cs-CZ"] = L"This function just works with Criteria and Whole together. 0/empty = no action, 1 = sorting of basic elements only, 2 = sort only consolidated elements";
      
          fd.arg_pool["type_limitation"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Level element";
        a.short_desc["de-DE"] = L"Elementebene";
        a.short_desc["fr-FR"] = L"Niveau";
        a.short_desc["cs-CZ"] = L">Level element";
        a.long_desc["en"] = L"This function works with Criteria and Whole only. If not empty, it will sort on the given level";
        a.long_desc["de-DE"] = L"Funktioniert nur zusammen mit Criteria und Whole. Falls nicht leer, sortiere nur auf der angegebenen Ebene";
        a.long_desc["fr-FR"] = L"Fonctionne uniquement avec Critère et Affichage. Si n’est pas vide, trie seulement sur les niveaux indiqués.";
        a.long_desc["cs-CZ"] = L"This function works with Criteria and Whole only. If not empty, it will sort on the given level";
      
          fd.arg_pool["level"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "reverse";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Reverse";
        a.short_desc["de-DE"] = L"Umgekehrt";
        a.short_desc["fr-FR"] = L"Inverse le tri";
        a.short_desc["cs-CZ"] = L"Otočit řazení";
        a.long_desc["en"] = L"Reverse the sorting. 0/empty = no action, 1= Consolidations below, 2 = total, 3= 1 and 2 combined";
        a.long_desc["de-DE"] = L"Kehrt die Sortierung um. 0/leer = keine Wirkung, 1= Konsolidierte Elemente unterhalb, 2= total, 3= 1 und 2 kombiniert";
        a.long_desc["fr-FR"] = L"0/vide = aucun effet\n1 = représentation hiérarchique avec les parents en-dessous des enfants et sur chaque niveau, tri selon Criteria\n2 = inversion complète du tri selon Criteria\n3 = représentation hiérarchique et inversement du tri selon Criteria sur chaque niveau.";
        a.long_desc["cs-CZ"] = L"Otočit řazení. 0/prázdné = žádná změna, 1 = konsolidace dole, 2 = celkem, 3 = kombinace 1 a 2";
      
          fd.arg_pool["reverse"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "show_duplicates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Show duplicates";
        a.short_desc["de-DE"] = L"Zeige Duplikate";
        a.short_desc["fr-FR"] = L"Afficher les doublons.";
        a.short_desc["cs-CZ"] = L"Zobrazit duplicitní";
        a.long_desc["en"] = L"Display of duplicate values, 0/empty = hide duplicates, 1 = show duplicates";
        a.long_desc["de-DE"] = L"Duplikatsanzeige: 0/leer = Zeige keine Duplikate an, 1 = Zeige Duplikate an";
        a.long_desc["fr-FR"] = L"Affichage des doublons, 0/vide n’affiche pas de duplicata, 1 autorise les duplicata.";
        a.long_desc["cs-CZ"] = L"Zobrazit duplicitní hodnoty, 0/prázdný = skrýt duplikáty, 1 = zobrazit duplikáty";
      
          fd.arg_pool["show_duplicates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "limit_count";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"limit count";
        a.short_desc["de-DE"] = L"Begrenze Anzahl";
        a.short_desc["fr-FR"] = L"Limite le nombre d'éléments retournés.";
        a.short_desc["cs-CZ"] = L"limit count";
        a.long_desc["en"] = L"limit the count of returned elements";
        a.long_desc["de-DE"] = L"Begrenze die Anzahl zurückgegebener Elemente";
        a.long_desc["fr-FR"] = L"Limite le nombre d'éléments retournés.";
        a.long_desc["cs-CZ"] = L"limit the count of returned elements";
      
          fd.arg_pool["limit_count"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "limit_start";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"start limiting at";
        a.short_desc["de-DE"] = L"Beginne Begrenzung bei";
        a.short_desc["fr-FR"] = L"Commence l'addition des éléments retournés à ";
        a.short_desc["cs-CZ"] = L"start limiting at";
        a.long_desc["en"] = L"start the limitation the count of returned elements at";
        a.long_desc["de-DE"] = L"Beginne die Begrenzung der Anzahl zurückgegebener Elemente bei";
        a.long_desc["fr-FR"] = L"Commence l'addition des éléments retournés à ";
        a.long_desc["cs-CZ"] = L"start the limitation the count of returned elements at";
      
          fd.arg_pool["limit_start"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("whole");
          p.arg_keys.push_back("criteria");
          p.arg_keys.push_back("attribute");
          p.arg_keys.push_back("type_limitation");
          p.arg_keys.push_back("level");
          p.arg_keys.push_back("reverse");
          p.arg_keys.push_back("show_duplicates");
          p.arg_keys.push_back("limit_count");
          p.arg_keys.push_back("limit_start");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("whole");
          p.arg_keys.push_back("criteria");
          p.arg_keys.push_back("attribute");
          p.arg_keys.push_back("type_limitation");
          p.arg_keys.push_back("level");
          p.arg_keys.push_back("reverse");
          p.arg_keys.push_back("show_duplicates");
          p.arg_keys.push_back("limit_count");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("whole");
          p.arg_keys.push_back("criteria");
          p.arg_keys.push_back("attribute");
          p.arg_keys.push_back("type_limitation");
          p.arg_keys.push_back("level");
          p.arg_keys.push_back("reverse");
          p.arg_keys.push_back("show_duplicates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetAliasFilter";
        fd.c_name = "palo_afilter";
        
        fd.xl_doc.xl_name = "PALO.AFILTER";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"The attribute filter removes elements which do not match with the defined attribut rows";
        fd.short_desc["de-DE"] = L"Der Attribut-Filter entfernt Elemente, auf die definierte Attributzeilen nicht zutreffen";
        fd.short_desc["fr-FR"] = L"Le filtre attribut supprime des éléments pour lesquels les lignes attribut définies ne correspondent pas.";
        fd.short_desc["cs-CZ"] = L"Filtr atribucí odstraní prvky, které nejsou v souladu s definovanými řádky atribucí.";
        fd.long_desc["en"] = L"The attribute filter removes elements which do not match with the defined attribut rows";
        fd.long_desc["de-DE"] = L"Der Attribut-Filter entfernt Elemente, auf die definierte Attributzeilen nicht zutreffen";
        fd.long_desc["fr-FR"] = L"Le filtre attribut supprime des éléments pour lesquels les lignes attribut définies ne correspondent pas.";
        fd.long_desc["cs-CZ"] = L"Filtr atribucí odstraní prvky, které nejsou v souladu s definovanými řádky atribucí.";
        {
          ArgumentDocumentation a;
    
          a.name = "advanced filter matrix";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Advanced filter matrix";
        a.short_desc["de-DE"] = L"Filtermatrix";
        a.short_desc["fr-FR"] = L"Matrice avancé de filtre";
        a.short_desc["cs-CZ"] = L"Filtr matice";
        a.long_desc["en"] = L"Array contains the definition for the field-filter. Supported operators for numeric criteria are: \" <, >, = \"";
        a.long_desc["de-DE"] = L"Array enthält die Definition für die Feld-Filter. Unterstützte Operatoren für nummerische Kriterien sind: \" <, >, = \"";
        a.long_desc["fr-FR"] = L"Matrice Filtre Avancée contient la définition pour les filtres-champs. Opérateurs supportés pour des critères numériques sont: &lt;, &gt;, \'=";
        a.long_desc["cs-CZ"] = L"Pole obsahuje definici pro filtr. Podporované operátory pro číselná kritéry jsou následující: <, >, =\"";
      
          fd.arg_pool["advanced filter matrix"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("advanced filter matrix");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetStructuralFilter";
        fd.c_name = "palo_hfilter";
        
        fd.xl_doc.xl_name = "PALO.HFILTER";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Defines hierarchically a subset with criteria relative to 1. ELEMENT or 2. REVOLVE_ELEMENT.  It should be specified only cover 1 or 2.";
        fd.short_desc["de-DE"] = L"Definiert hierarchisch ein Subset über Kriterien in Bezug auf 1. ELEMENT  oder 2. REVOLVE_ELEMENT. Es sollte nur Bezug 1 oder 2 angegeben werden";
        fd.short_desc["fr-FR"] = L"1. Filtre des éléments à partir d’un sous-ensemble en définissant des critères de structure. 2. Répétition d’un sous ensemble avec des critères de structure légèrement modifiés. Point 1 et Point";
        fd.short_desc["cs-CZ"] = L"1. Filtrovat prvky subsetu definováním kritérií struktur. 2. Opakování subsetu s rozdílnou strukturou. Případy 1 a 2 nelze kombinovat.";
        fd.long_desc["en"] = L"Defines hierarchically a subset with criteria relative to 1. ELEMENT or 2. REVOLVE_ELEMENT.  It should be specified only cover 1 or 2.";
        fd.long_desc["de-DE"] = L"Definiert hierarchisch ein Subset über Kriterien in Bezug auf 1. ELEMENT  oder 2. REVOLVE_ELEMENT. Es sollte nur Bezug 1 oder 2 angegeben werden";
        fd.long_desc["fr-FR"] = L"1. Filtre des éléments à partir d’un sous-ensemble en définissant des critères de structure. 2. Répétition d’un sous ensemble avec des critères de structure légèrement modifiés. Point 1 et Point";
        fd.long_desc["cs-CZ"] = L"1. Filtrovat prvky subsetu definováním kritérií struktur. 2. Opakování subsetu s rozdílnou strukturou. Případy 1 a 2 nelze kombinovat.";
        {
          ArgumentDocumentation a;
    
          a.name = "element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Selection of elements, which are above or below of ELEMENT in the hierarchy. Empty = elements below ELEMENT, TRUE = elements above ELEMENT will be displayed.";
        a.long_desc["de-DE"] = L"Auswahl von Elementen, die in der Hierarchie über oder unter ELEMENT liegen. Leer = Darunterliegende,  WAHR = Darüberliegende Elemente werden genommen";
        a.long_desc["fr-FR"] = L"Permet la sélection d'éléments qui se situent dans la hiérarchie de dimension au-dessus ou au-dessous de « l'élément ».";
        a.long_desc["cs-CZ"] = L"Výběr prvků, které jsou nad nebo pod PRVKEM v hierarchii. Prázdné = prvky pod PRVKEM, PRAVDA = prvky nad PRVKEM budou zobrazeny.";
      
          fd.arg_pool["element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "above";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Above";
        a.short_desc["de-DE"] = L"Oberhalb";
        a.short_desc["fr-FR"] = L"Au-dessus";
        a.short_desc["cs-CZ"] = L"Výe";
        a.long_desc["en"] = L"This criteria works only with element. TRUE = All elements in higher-level hierarchy will be handled. FALSE/empty = All elements in less-level hierarchy will be handled.";
        a.long_desc["de-DE"] = L"Kann nur zusammen mit Element verwendet werden. WAHR = Alle Elemente, die in der Hierarchie oberhalb stehen, FALSCH/leer = Alle Elemente, die in der Hierarchie unterhalb stehen, werden genommen";
        a.long_desc["fr-FR"] = L"Ne peut être utilisé uniquement qu’avec Élément. VRAI = tous les éléments au-dessus de «l'élément» sont pris. FAUX/vide = tous les éléments au-dessous de «l'élément» sont";
        a.long_desc["cs-CZ"] = L"Toto kritérium funguje pouze s prvkem. PRAVDA = Všechny prvky ve vyšší úrovni hierarchie budou zpracovány. NEPRAVDA/prázdné = Všechny prvky v nižší úrovni hierarchie budou zpracovány.";
      
          fd.arg_pool["above"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "exclusive";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Exclusive";
        a.short_desc["de-DE"] = L"Exclusiv";
        a.short_desc["fr-FR"] = L"Exclusif";
        a.short_desc["cs-CZ"] = L"Exkluzivní";
        a.long_desc["en"] = L"TRUE = Element will not be shown. FALSE or empty = Element will be shown.";
        a.long_desc["de-DE"] = L"WAHR = Das Element wird nicht angezeigt. FALSE oder Leer = Das Element selbst wird mit angezeigt";
        a.long_desc["fr-FR"] = L"\"VRAI\" = L'élément lui-même n'est pas montré. \"FAUX\" ou Vide = L'élément lui-même est aussi montré.";
        a.long_desc["cs-CZ"] = L"\"PRAVDA\":  Prvek bude zobrazen. \"NEPRAVDA\" nebo prázdné: Prvek nebude zobrazen.";
      
          fd.arg_pool["exclusive"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "hide";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Hide";
        a.short_desc["de-DE"] = L"Verborgen";
        a.short_desc["fr-FR"] = L"Masquer";
        a.short_desc["cs-CZ"] = L"Skrytý";
        a.long_desc["en"] = L"This cireteria works only with Element. 1 = basic elements will be blanked out. 2 = consolidated elements will be blanked out.";
        a.long_desc["de-DE"] = L"Kann nur mit Element zusammen verwendet werden. 1 = Basiselemente werden ausgeblendet. 2 = Konsolidierte Elemente werden ausgeblendet";
        a.long_desc["fr-FR"] = L"Ne peut être utilisé uniquement qu’avec Élément. 1 = éléments de base sont cachés. 2 = éléments consolidés sont cachés. Vide = Rien n'est caché.";
        a.long_desc["cs-CZ"] = L"Toto kritérium funguje pouze s prvkem. 1 = základní prvky budou odstraněny. 2 = konsolidované prvky budou odstraněny.";
      
          fd.arg_pool["hide"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_elem";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Revolve elem";
        a.short_desc["de-DE"] = L"Wiederhol.element";
        a.short_desc["fr-FR"] = L"Élément à répéter";
        a.short_desc["cs-CZ"] = L"Prvek opakování";
        a.long_desc["en"] = L"This criteria do not work with Element. Elements, which are not at level of REVOLVE ELEMENT will be removed.";
        a.long_desc["de-DE"] = L"Kann nicht zusammen mit Element verwendet werden. Elemente, die nicht auf dem Level vom Wiederholungselement sind, werden entfernt";
        a.long_desc["fr-FR"] = L"Ne peut pas être utilisé avec Élément. Des éléments qui ne sont au niveau de « Rotation_elem » sont supprimés.";
        a.long_desc["cs-CZ"] = L"This criteria do not work with Element. Elements, which are not at level of REVOLVE ELEMENT will be removed.";
      
          fd.arg_pool["revolve_elem"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_count";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Revolve count";
        a.short_desc["de-DE"] = L"Wiederhol.anzahl";
        a.short_desc["fr-FR"] = L"Nombre de répétition";
        a.short_desc["cs-CZ"] = L"Revolve count";
        a.long_desc["en"] = L"Defines the length of the revolving list (also without REVOLVE-arguments possible). List length responds to the entered number.";
        a.long_desc["de-DE"] = L"Bestimmt die Länge der sich wiederholenden Liste (Angabe ist auch ohne andere Wiederhol.-Argumente möglich). Listenlänge entspricht der eingegebenen Zahl";
        a.long_desc["fr-FR"] = L"Définit la longueur de la liste récurrente (également possible sans arguments « Rotation_elem »). Liste correspond au nombre indiqué.";
        a.long_desc["cs-CZ"] = L"Defines the length of the revolving list (without REVOLVE-arguments possible). List length responds to the entered number.";
      
          fd.arg_pool["revolve_count"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_add";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Revolve add";
        a.short_desc["de-DE"] = L"Wiederhol.zugabe";
        a.short_desc["fr-FR"] = L"Ajout à répéter";
        a.short_desc["cs-CZ"] = L"Zobrazí prvky s vyšší úrovní (REVOLVE ADD = 1) nebo nižší úrovní (REVOLVE ADD = 2).";
        a.long_desc["en"] = L"Shows  in addition elements with higher level (REVOLVE ADD = 1) or with a lower level (REVOLVE ADD = 2).";
        a.long_desc["de-DE"] = L"Zeigt zusätzlich die Elemente mit höherem Level (REVOLVE ADD = 1) bzw. mit niedrigerem Level (REVOLVE ADD = 2) an";
        a.long_desc["fr-FR"] = L"Montre les éléments avec le niveau le plus haut (Rotation ADD = 1) ou avec le niveau le plus bas (Rotation ADD = 2)";
        a.long_desc["cs-CZ"] = L"Zobrazí prvky s vyšší úrovní (REVOLVE ADD = 1) nebo nižší úrovní (REVOLVE ADD = 2).";
      
          fd.arg_pool["revolve_add"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level_start";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Start level";
        a.short_desc["de-DE"] = L"Startlevel";
        a.short_desc["fr-FR"] = L"Niveau de départ";
        a.short_desc["cs-CZ"] = L"Start level";
        a.long_desc["en"] = L"Beginning of the hierarchical choice at level of this element (if empty, no hierarchical choice).";
        a.long_desc["de-DE"] = L"Beginn der hierarchischen Auswahl auf Ebene dieses Elements (falls leer, keine hierarchische Auswahl)";
        a.long_desc["fr-FR"] = L"Début de la sélection hiérarchique au niveau de l’élément (si vide, pas de sélection hiérarchique)";
        a.long_desc["cs-CZ"] = L"Začátek hierarchického výběru na úrovni tohoto prvku (pokud je prázdné, není žádný hierarchický výběr)";
      
          fd.arg_pool["level_start"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level_end";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"End level";
        a.short_desc["de-DE"] = L"Endlevel";
        a.short_desc["fr-FR"] = L"Niveau de fin";
        a.short_desc["cs-CZ"] = L"End level";
        a.long_desc["en"] = L"The end of the hierarchical choice at level ot this element (if empty, until the top element)";
        a.long_desc["de-DE"] = L"Ende der hierarchischen Auswahl auf Ebene dieses Elements (falls leer, bis zum Topelement)";
        a.long_desc["fr-FR"] = L"Fin de la sélection hiérarchique au niveau de l’élément (si vide, jusqu’à l’élément Top)";
        a.long_desc["cs-CZ"] = L"The end of the hierarchical choice at level ot this element (if empty, until the top element)";
      
          fd.arg_pool["level_end"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("element");
          p.arg_keys.push_back("above");
          p.arg_keys.push_back("exclusive");
          p.arg_keys.push_back("hide");
          p.arg_keys.push_back("revolve_elem");
          p.arg_keys.push_back("revolve_count");
          p.arg_keys.push_back("revolve_add");
          p.arg_keys.push_back("level_start");
          p.arg_keys.push_back("level_end");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubsetDataFilter";
        fd.c_name = "palo_dfilter";
        
        fd.xl_doc.xl_name = "PALO.DFILTER";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"A data value will be investigated for each element of a subset. This value can be from type of numeric or string.";
        fd.short_desc["de-DE"] = L"Ermittelt für jedes Element eines Subsets einen Datenwert. Der Wert kann numerisch oder ein String sein ";
        fd.short_desc["fr-FR"] = L"Calcule pour chaque élément d’un sous-ensemble une valeur de données. La valeur peut être numérique ou un String. ";
        fd.short_desc["cs-CZ"] = L"Datová hodnota bude prošetřována pro každý prvek subsetu. Tato hodnota může být číselného nebo textového typu.";
        fd.long_desc["en"] = L"A data value will be investigated for each element of a subset. This value can be from type of numeric or string.";
        fd.long_desc["de-DE"] = L"Ermittelt für jedes Element eines Subsets einen Datenwert. Der Wert kann numerisch oder ein String sein ";
        fd.long_desc["fr-FR"] = L"Calcule pour chaque élément d’un sous-ensemble une valeur de données. La valeur peut être numérique ou un String. ";
        fd.long_desc["cs-CZ"] = L"Datová hodnota bude prošetřována pro každý prvek subsetu. Tato hodnota může být číselného nebo textového typu.";
        {
          ArgumentDocumentation a;
    
          a.name = "subcube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Subcube";
        a.short_desc["de-DE"] = L"Subcube";
        a.short_desc["fr-FR"] = L"Subcube";
        a.short_desc["cs-CZ"] = L"Subcube";
        a.long_desc["en"] = L"Palo.Subcube is necassary for DFilter. Arguments are cube name and its dimensions without the Dimensionwhich is included in the subset. This one has to be empty.";
        a.long_desc["de-DE"] = L"Palo.Subcube ist für DFilter notwendig. Die Argumente sind der Name des Würfels und seine Dimensionen, ohne die Dimension, die durch das Subset abgedeckt wird. Diese Stelle bleibt leer ";
        a.long_desc["fr-FR"] = L"Palo.Subcube est nécessaire pour PALO.DFILTER. Les arguments sont le nom du cube et ses dimensions sans la dimension qui est recouverte par la feuille. Cette dernière reste vide. ";
        a.long_desc["cs-CZ"] = L"Palo.Subcube je vyžadována pro DFilter. Argumenty jsou názvy kostek a jejich dimenzí bez dimenze, která je zařazená do subsetu. Tato musí být prázdná.";
      
          fd.arg_pool["subcube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "operations";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Operations";
        a.short_desc["de-DE"] = L"Operationen";
        a.short_desc["fr-FR"] = L"Opérations";
        a.short_desc["cs-CZ"] = L"Operace";
        a.long_desc["en"] = L"Designation of criteria for the defined values of each element . Possible operators are \" <,>,<>,= \" ";
        a.long_desc["de-DE"] = L"Damit wird bestimmt, welche Kriterien auf die für jedes Element ermittelten Werte angewendet werden. Mögliche Operatoren sind \" <,>,<>,= \" ";
        a.long_desc["fr-FR"] = L"Il sera ainsi défini quels critères sont utilisés pour les valeurs calculées pour chaque élément. Les opérateurs possibles sont <,>,<>,=\" ";
        a.long_desc["cs-CZ"] = L"Určení kritérií pro definované hodnoty každého prvku. Je možné použít operátory <, >, <> a =.";
      
          fd.arg_pool["operations"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "top";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Top";
        a.short_desc["de-DE"] = L"Top";
        a.short_desc["fr-FR"] = L"Supérieur";
        a.short_desc["cs-CZ"] = L"Vrchol";
        a.long_desc["en"] = L"Optional. In case an integer value TOP is passed, only a number of TOP elements with the highest values are displayed. If the argument is left blank, the elements will not be restricted.";
        a.long_desc["de-DE"] = L"Optional. Falls hier ein ganzzahliger Wert TOP übergeben wird, werden lediglich die ersten TOP Elemente mit den größten Werten gezeigt. Wenn das Argument leer bleibt, werden die Elemente nicht weiter eingeschränkt ";
        a.long_desc["fr-FR"] = L"Optionel. Si une valeur TOP en nombre entiers est rendue, seuls les premiers éléments TOP avec les plus grandes valeurs sont affichés. Si l’argument reste vide, les éléments ne seront plus restreints. ";
        a.long_desc["cs-CZ"] = L"Optional. In case an integer value TOP is passed, only a number of TOP elements with the highest values are displayed. If the argument is left blank, the elements will not be restricted.";
      
          fd.arg_pool["top"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "upper_percentage";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Upper percentage";
        a.short_desc["de-DE"] = L"Oberer Proz.ber.";
        a.short_desc["fr-FR"] = L"Pourcentage supérieur";
        a.short_desc["cs-CZ"] = L"Horní procenta";
        a.long_desc["en"] = L"If a numeric value between 1 and 99 is entered here, when only those largest elements are selected, whose total value is closest to the limit. The selection starts at the largest element, adds the second largest, etc.";
        a.long_desc["de-DE"] = L"Falls hier ein numerischer Wert zwischen 1 und 99 (inklusive) eingetragen wird, so werden nur diejenigen größten Elemente gewählt, deren Gesamtwert dem Grenzwert am nächsten kommt. Die Selektion beginnt beim größten Element ";
        a.long_desc["fr-FR"] = L"Avec des valeurs numériques de 1 à 99, il est possible de choisir des éléments dont les valeurs cumulées rendent une valeur totale inférieure à la valeur limite. La sélection commence par la valeur la plus grande. ";
        a.long_desc["cs-CZ"] = L"Pouze číselné hodnoty mezi 1 a 99 budou vybrány, pokud jejich kumulované hodnoty vyústí v celkovou hodnotu, která je nižší než krajní hodnota. Toto zpracování začíná s nejvyšším prvkem.";
      
          fd.arg_pool["upper_percentage"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "lower_percentage";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Lower percentage";
        a.short_desc["de-DE"] = L"Unterer Proz.ber.";
        a.short_desc["fr-FR"] = L"Pourcentage inférieur ";
        a.short_desc["cs-CZ"] = L"Nií procenta";
        a.long_desc["en"] = L"If a numeric value between 1 and 99 is entered here, when only those smallest elements are selected, whose total value is closest to the limit. The selection starts at the smallest element, adds the second smallest, etc.";
        a.long_desc["de-DE"] = L"Falls hier ein numerischer Wert  zwischen 1 und 99 (inklusive) eingetragen wird, so werden nur diejenigen kleinsten Elemente gewählt, deren Gesamtwert dem Grenzwert am nächsten kommt. Die Selektion beginnt beim kleinsten Element, addiert dazu ";
        a.long_desc["fr-FR"] = L"Valeurs numériques de  1 à 99. Si la valeur est par exemple indiquée, tous les éléments cumulés < = 20% seront sélectionnés. La sélection commence par la plus petite valeur. ";
        a.long_desc["cs-CZ"] = L"Numerická hodnota mezi 1 a 99. Jestli je zadána např. hodnota 20, všechny kumulované prvky, které jsou menší nebo rovno 20 % budou zpracované. Zpracování začíná od nejnižšího prvku.";
      
          fd.arg_pool["lower_percentage"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cell_operator";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cell operator";
        a.short_desc["de-DE"] = L"Zelloperator";
        a.short_desc["fr-FR"] = L"Opérateur";
        a.short_desc["cs-CZ"] = L"Operátor";
        a.long_desc["en"] = L"Will be applied to each slice. Operators: 0/empty = SUM, 1=ALL, 2=AVERAGE, 3=MAXIMUM, 4=any, 5=MINIMUM, 7=TEXT. Only elements will be returned, not the values.";
        a.long_desc["de-DE"] = L"Wird auf den Slice angewendet. Operatoren: 0/leer = SUMME, 1=ALLE, 2=MITTELWERT, 3=MAXIMUM, 4=Beliebig, 5=MINIMUM, 7=TEXT. Zurückgegeben werden die Elemente – nicht die Werte ";
        a.long_desc["fr-FR"] = L"Est utilisé sur le Slice. Opérateurs: 0/vide = SOMME, 1=TOUS, 2=MOYENNE, 3=MAXIMUM,4=quelconque, 5=MINIMUM, 7=TEXTE Les éléments sont renvoyés – pas les valeurs ";
        a.long_desc["cs-CZ"] = L"Bude použito na každý řez. Operátory: 0/prázdný = SUMA, 1=VŠE, 2=PRŮMĚR, 3=MAXIMUM,4=libovolný, 5=MINIMUM, 7=TEXT. Budou vráceny pouze prvky, nikoli hodnoty.";
      
          fd.arg_pool["cell_operator"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "no_rules";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"No rules.";
        a.short_desc["de-DE"] = L"Ohne Regeln";
        a.short_desc["fr-FR"] = L"No rules";
        a.short_desc["cs-CZ"] = L"Bez pravidel";
        a.long_desc["en"] = L"blank/FALSE = Takes cell content with the applied Rules. TRUE = Rules are not applied.";
        a.long_desc["de-DE"] = L"Leer/FALSCH = Nehme Zellinhalte mit Berücksichtigung der Rules. WAHR = Berücksichtige keine Rules ";
        a.long_desc["fr-FR"] = L"Vide/Faux= contenus de cellule extraits compte tenu des Enterprise-Rules. Vrai = ne tient pas compte des Enterprise-Rules.";
        a.long_desc["cs-CZ"] = L"blank/false = extracted cell content with Enterprise Rules True = Enterprise Rules not to be applied.";
      
          fd.arg_pool["no_rules"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("subcube");
          p.arg_keys.push_back("operations");
          p.arg_keys.push_back("top");
          p.arg_keys.push_back("upper_percentage");
          p.arg_keys.push_back("lower_percentage");
          p.arg_keys.push_back("cell_operator");
          p.arg_keys.push_back("no_rules");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloSubcube";
        fd.c_name = "palo_subcube";
        
        fd.xl_doc.xl_name = "PALO.SUBCUBE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Is necessary for Palo DFilter. The function gets the slice as an argument. The Dimensionof the subset has to be empty. The respectivly element will be inserted here. For each Dimensioncan be indicated any elements.";
        fd.short_desc["de-DE"] = L"Ist erforderlich für Palo DFilter. Die Funktion bekommt den Slice als Argument. Die Dimensiondes SubSets wird leer gelassen. Hier wird dann das jeweilige Element intern eingesetzt. Man kann für jede Dimensionbeliebig viele Elemente angeben";
        fd.short_desc["fr-FR"] = L"Est indispensable pour Palo DFilter. Fonction qui obtient le Slice en tant qu’argument. La dimension du sous-ensemble est laissée vide. Chaque élément est constitué ainsi en interne. Il est possible pour chaque dimension d’indiquer autant d’éléments que souhaités. Au moins est cependant nécessaire (TODO: ou \"*\" pour tous).";
        fd.short_desc["cs-CZ"] = L"Tato funkce je nutná pro funkci Palo DFiltr. Funkce vrátí řez jako argument. Dimenze subsetu musí být prázdné. Odpovídající prvek bude vložen sem. Pro každou dimenzi můžou být určeny jakékoli prvky.";
        fd.long_desc["en"] = L"This function is necessary for Palo DFilter. The function gets the slice as an argument. The Dimensionof the subset has to be empty. The respectivly element will be inserted here. For each Dimensioncan be indicated any elements.";
        fd.long_desc["de-DE"] = L"Diese Funktion ist erforderlich für Palo DFilter. Die Funktion bekommt den Slice als Argument . Die Dimension des SubSets wird leer gelassen. Hier wird dann das jeweilige Element intern eingesetzt. Man kann für jede Dimension beliebig viele El";
        fd.long_desc["fr-FR"] = L"Est indispensable pour Palo DFilter. Fonction qui obtient le Slice en tant qu’argument. La dimension du sous-ensemble est laissée vide. Chaque élément est constitué ainsi en interne. Il est possible pour chaque dimension d’indiquer autant d’éléments que souhaités. Au moins est cependant nécessaire (TODO: ou \"*\" pour tous).";
        fd.long_desc["cs-CZ"] = L"Tato funkce je nutná pro funkci Palo DFiltr. Funkce vrátí řez jako argument. Dimenze subsetu musí být prázdné. Odpovídající prvek bude vložen sem. Pro každou dimenzi můžou být určeny jakékoli prvky.";
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "element";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"The names of the Dimensions, that form the subcube, so that the elements were delimitated which have to be filtered. The place, where normaly the Dimensionfrom the subset stands, has to be empty.";
        a.long_desc["de-DE"] = L"Die Namen der Dimensionen, die den Subcube bildet und somit die Elemente einschränkt, die gefiltert werden sollen. Der Platz der Dimensiondes Subset wird leer gelassen";
        a.long_desc["fr-FR"] = L"Nom des dimensions qui forme le sous-ensemble et ainsi limite les éléments qui doivent être triés sachant que la place pour la dimension du sous-ensemble est laissée vide.";
        a.long_desc["cs-CZ"] = L"Name of the Dimensions, that form the subcube, so that the elements were delimitated which have to be filtered. The place, where normaly the dimension from the subset stands has to be empty";
      
          fd.arg_pool["element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("cube");
          p.arg_keys.push_back("element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDisconnect";
        fd.c_name = "palo_disconnect";
        fd.short_desc["en"] = L"Close a connection.";
        fd.short_desc["de-DE"] = L"Trennt eine Verbindung";
        fd.short_desc["fr-FR"] = L"Déconnecte une connexion.";
        fd.short_desc["cs-CZ"] = L"Close a connection";
        fd.long_desc["de-DE"] = L"Trennt eine Verbindung";
        fd.long_desc["fr-FR"] = L"Déconnecte une connexion.";
        {
          ArgumentDocumentation a;
    
          a.name = "connection";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Connection";
        a.short_desc["de-DE"] = L"Verbindung";
        a.short_desc["fr-FR"] = L"Connexion";
        a.short_desc["cs-CZ"] = L"Connection";
        a.long_desc["en"] = L"The connection to be closed.";
        a.long_desc["de-DE"] = L"Die zu trennende Verbindung";
        a.long_desc["fr-FR"] = L"La connexion qui sera être coupé.";
        a.long_desc["cs-CZ"] = L"The connection to be closed.";
      
          fd.arg_pool["connection"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("connection");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloCubeClear";
        fd.c_name = "palo_cube_clear";
        fd.short_desc["en"] = L"Clears a cube or part of it.";
        fd.short_desc["de-DE"] = L"Löscht einen Würfel oder einen Teil davon";
        fd.short_desc["fr-FR"] = L"Vide un cube ou une partie de celui-ci.";
        fd.short_desc["cs-CZ"] = L"Clears a cube or part of it.";
        fd.long_desc["en"] = L"Clears a cube or part of it.";
        fd.long_desc["de-DE"] = L"Löscht einen Würfel oder einen Teil davon";
        fd.long_desc["fr-FR"] = L"Vide un cube ou une partie de celui-ci.";
        fd.long_desc["cs-CZ"] = L"Clears a cube or part of it.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "area";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Area to be cleared";
        a.short_desc["de-DE"] = L"Zu löschender Bereich";
        a.short_desc["fr-FR"] = L"Plage à supprimer";
        a.short_desc["cs-CZ"] = L"Area to be cleared";
        a.long_desc["en"] = L"Area to be cleared.";
        a.long_desc["de-DE"] = L"Zu löschender Bereich";
        a.long_desc["fr-FR"] = L"Plage à supprimer.";
        a.long_desc["cs-CZ"] = L"Area to be cleared.";
      
          fd.arg_pool["area"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
      
          fd.prototypes.push_back(p);
        } 
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
          p.arg_keys.push_back("area");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionClear";
        fd.c_name = "palo_dimension_clear";
        fd.short_desc["en"] = L"Clears the elements of a dimension.";
        fd.short_desc["de-DE"] = L"Löscht die Elemente einer Dimension";
        fd.short_desc["fr-FR"] = L"Efface les éléments d'une dimension.";
        fd.short_desc["cs-CZ"] = L"Clears the elements of a dimension.";
        fd.long_desc["en"] = L"Clears the elements of a dimension.";
        fd.long_desc["de-DE"] = L"Löscht die Elemente einer Dimension";
        fd.long_desc["fr-FR"] = L"Efface les éléments d'une dimension.";
        fd.long_desc["cs-CZ"] = L"Clears the elements of a dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the Dimension whose elements are to be deleted.";
        a.long_desc["de-DE"] = L"Name der Dimension, deren Elemente gelöscht werden sollen";
        a.long_desc["fr-FR"] = L"Name of the Dimensionwhose elements are to be deleted.";
        a.long_desc["cs-CZ"] = L"Name of the Dimension whose elements are to be deleted.";
      
          fd.arg_pool["dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloRootAddDatabase";
        fd.c_name = "palo_root_add_database";
        fd.short_desc["en"] = L"Add a database.";
        fd.short_desc["de-DE"] = L"Eine Datenbank hinzufügen";
        fd.short_desc["fr-FR"] = L"Ajoute une base de données.";
        fd.short_desc["cs-CZ"] = L"Add a database.";
        fd.long_desc["en"] = L"Add a database.";
        fd.long_desc["de-DE"] = L"Eine Datenbank hinzufügen";
        fd.long_desc["fr-FR"] = L"Ajoute une base de données.";
        fd.long_desc["cs-CZ"] = L"Add a database.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Type";
        a.short_desc["de-DE"] = L"Typ";
        a.short_desc["fr-FR"] = L"Type";
        a.short_desc["cs-CZ"] = L"Typ";
        a.long_desc["en"] = L"Type of the Database (0=normal,1=system,3=userinfo)";
        a.long_desc["de-DE"] = L"Typ der Datenbank (0=normal,1=system,3=userinfo)";
        a.long_desc["fr-FR"] = L"Type de la base de données (0=normal,1=système,3=info d'utilisateur)";
        a.long_desc["cs-CZ"] = L"Type of the Database (0=normal,1=system,3=userinfo)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Type");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloRootDeleteDatabase";
        fd.c_name = "palo_root_delete_database";
        fd.short_desc["en"] = L"Delete a database.";
        fd.short_desc["de-DE"] = L"Löscht eine Datenbank";
        fd.short_desc["fr-FR"] = L"Supprime une base de données.";
        fd.short_desc["cs-CZ"] = L"Delete a database.";
        fd.long_desc["en"] = L"Delete a database.";
        fd.long_desc["de-DE"] = L"Löscht eine Datenbank";
        fd.long_desc["fr-FR"] = L"Supprime une base de données.";
        fd.long_desc["cs-CZ"] = L"Delete a database.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseLoadCube";
        fd.c_name = "palo_database_load_cube";
        fd.short_desc["en"] = L"Load a cube.";
        fd.short_desc["de-DE"] = L"Ladet einen Würfel";
        fd.short_desc["fr-FR"] = L"Charge un cube.";
        fd.short_desc["cs-CZ"] = L"Load a cube.";
        fd.long_desc["en"] = L"Load a cube.";
        fd.long_desc["de-DE"] = L"Ladet einen Würfel";
        fd.long_desc["fr-FR"] = L"Charge un cube.";
        fd.long_desc["cs-CZ"] = L"Load a cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseUnloadCube";
        fd.c_name = "palo_database_unload_cube";
        fd.short_desc["en"] = L"Unload a cube.";
        fd.short_desc["de-DE"] = L"Leert einen Würfel";
        fd.short_desc["fr-FR"] = L"Vide un cube.";
        fd.short_desc["cs-CZ"] = L"Unload a cube.";
        fd.long_desc["en"] = L"Unload a cube.";
        fd.long_desc["de-DE"] = L"Leert einen Würfel";
        fd.long_desc["fr-FR"] = L"Vide un cube.";
        fd.long_desc["cs-CZ"] = L"Unload a cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseAddCube";
        fd.c_name = "palo_database_add_cube";
        fd.short_desc["en"] = L"Add a cube.";
        fd.short_desc["de-DE"] = L"Fügt einen Würfel hinzu";
        fd.short_desc["fr-FR"] = L"Ajoute un cube.";
        fd.short_desc["cs-CZ"] = L"Add a cube.";
        fd.long_desc["en"] = L"Add a cube.";
        fd.long_desc["de-DE"] = L"Fügt einen Würfel hinzu";
        fd.long_desc["fr-FR"] = L"Ajoute un cube.";
        fd.long_desc["cs-CZ"] = L"Add a cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseDeleteCube";
        fd.c_name = "palo_database_delete_cube";
        fd.short_desc["en"] = L"Delete a cube.";
        fd.short_desc["de-DE"] = L"Löscht einen Würfel";
        fd.short_desc["fr-FR"] = L"Supprime un cube.";
        fd.short_desc["cs-CZ"] = L"Delete a cube.";
        fd.long_desc["en"] = L"Delete a cube.";
        fd.long_desc["de-DE"] = L"Löscht einen Würfel";
        fd.long_desc["fr-FR"] = L"Supprime un cube.";
        fd.long_desc["cs-CZ"] = L"Delete a cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseAddDimension";
        fd.c_name = "palo_database_add_dimension";
        fd.short_desc["en"] = L"Adds a dimension.";
        fd.short_desc["de-DE"] = L"Fügt eine Dimensionhinzu";
        fd.short_desc["fr-FR"] = L"Ajoute une dimension.";
        fd.short_desc["cs-CZ"] = L"Adds a dimension.";
        fd.long_desc["en"] = L"Adds a dimension.";
        fd.long_desc["de-DE"] = L"Fügt eine Dimensionhinzu";
        fd.long_desc["fr-FR"] = L"Ajoute une dimension.";
        fd.long_desc["cs-CZ"] = L"Adds a dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the Dimensionthat will be added.";
        a.long_desc["de-DE"] = L"Name der Dimension, die hinzugefügt wird";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui sera ajouté.";
        a.long_desc["cs-CZ"] = L"Name of the Dimensionthat will be added.";
      
          fd.arg_pool["dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseDeleteDimension";
        fd.c_name = "palo_database_delete_dimension";
        fd.short_desc["en"] = L"Deletes a dimension.";
        fd.short_desc["de-DE"] = L"Löscht eine Dimension";
        fd.short_desc["fr-FR"] = L"Supprime une dimension.";
        fd.short_desc["cs-CZ"] = L"Deletes a dimension.";
        fd.long_desc["en"] = L"Deletes a dimension.";
        fd.long_desc["de-DE"] = L"Löscht eine Dimension";
        fd.long_desc["fr-FR"] = L"Supprime une dimension.";
        fd.long_desc["cs-CZ"] = L"Deletes a dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the Dimension which should be deleted.";
        a.long_desc["de-DE"] = L"Name der Dimension, die gelöscht werden soll";
        a.long_desc["fr-FR"] = L"Name of the Dimensionthat should be deleted.";
        a.long_desc["cs-CZ"] = L"Name of the Dimension which should be deleted.";
      
          fd.arg_pool["dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloStartCacheCollect";
        fd.c_name = "palo_startcachecollect";
        fd.short_desc["en"] = L"Begins request collect.";
        fd.short_desc["de-DE"] = L"Startet die Abfrage";
        fd.short_desc["fr-FR"] = L"Commence la demande.";
        fd.short_desc["cs-CZ"] = L"Begins request collect.";
        fd.long_desc["en"] = L"Begins request collect.";
        fd.long_desc["de-DE"] = L"Startet die Abfrage";
        fd.long_desc["fr-FR"] = L"Commence la demande.";
        fd.long_desc["cs-CZ"] = L"Begins request collect.";
        {
          PrototypeDocumentation p;
    
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloEndCacheCollect";
        fd.c_name = "palo_endcachecollect";
        fd.short_desc["en"] = L"Ends request collect.";
        fd.short_desc["de-DE"] = L"Beendet Abfrage";
        fd.short_desc["fr-FR"] = L"Arrête la demande.";
        fd.short_desc["cs-CZ"] = L"Ends request collect.";
        fd.long_desc["en"] = L"End request collect.";
        fd.long_desc["de-DE"] = L"Beendet Abfrage";
        fd.long_desc["fr-FR"] = L"Arrête la demande.";
        fd.long_desc["cs-CZ"] = L"End request collect.";
        {
          PrototypeDocumentation p;
    
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDatabaseRenameDimension";
        fd.c_name = "palo_database_rename_dimension";
        fd.short_desc["en"] = L"Rename a dimension.";
        fd.short_desc["de-DE"] = L"Benennt eine Dimension um";
        fd.short_desc["fr-FR"] = L"Renomme une dimension.";
        fd.short_desc["cs-CZ"] = L"Rename a dimension.";
        fd.long_desc["en"] = L"Rename a dimension.";
        fd.long_desc["de-DE"] = L"Benennt eine Dimension um";
        fd.long_desc["fr-FR"] = L"Renomme une dimension.";
        fd.long_desc["cs-CZ"] = L"Rename a dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "old_dim_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Current Dimensionname.";
        a.short_desc["de-DE"] = L"Aktueller Name der Dimension";
        a.short_desc["fr-FR"] = L"Actuel nom de la dimension.";
        a.short_desc["cs-CZ"] = L"Current Dimensionname.";
        a.long_desc["en"] = L"Name of the Dimension which should be renamed.";
        a.long_desc["de-DE"] = L"Name der Dimension, die umbenannt werden soll";
        a.long_desc["fr-FR"] = L"Nom de la dimension qui devrait être renommé.";
        a.long_desc["cs-CZ"] = L"Name of the Dimension which should be renamed.";
      
          fd.arg_pool["old_dim_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "new_dim_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"New Dimensionname";
        a.short_desc["de-DE"] = L"Neuer Dimensionsname";
        a.short_desc["fr-FR"] = L"Nouveau nom de la dimension";
        a.short_desc["cs-CZ"] = L"New Dimensionname";
        a.long_desc["en"] = L"New Dimensionname";
        a.long_desc["de-DE"] = L"Neuer Dimensionsname";
        a.long_desc["fr-FR"] = L"Nouveau nom de la dimension.";
        a.long_desc["cs-CZ"] = L"New Dimensionname";
      
          fd.arg_pool["new_dim_name"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("old_dim_name");
          p.arg_keys.push_back("new_dim_name");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloCubeRename";
        fd.c_name = "palo_rename_cube";
        fd.short_desc["en"] = L"Rename a cube.";
        fd.short_desc["de-DE"] = L"Benennt einen Würfel um";
        fd.short_desc["fr-FR"] = L"Renomme un cube.";
        fd.short_desc["cs-CZ"] = L"Rename a cube.";
        fd.long_desc["en"] = L"Rename a cube.";
        fd.long_desc["de-DE"] = L"Benennt einen Würfel um";
        fd.long_desc["fr-FR"] = L"Renomme un cube.";
        fd.long_desc["cs-CZ"] = L"Rename a cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "old_cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Current cube name";
        a.short_desc["de-DE"] = L"Aktueller Würfelname";
        a.short_desc["fr-FR"] = L"Le nom actuel du cube";
        a.short_desc["cs-CZ"] = L"Current cube name";
        a.long_desc["en"] = L"Name of the cube which should be renamed.";
        a.long_desc["de-DE"] = L"Name des Würfels, der umbenannt werden soll";
        a.long_desc["fr-FR"] = L"Le nom du cube qui devrait être renommé.";
        a.long_desc["cs-CZ"] = L"Name of the cube which should be renamed.";
      
          fd.arg_pool["old_cube_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "new_cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"New cube name";
        a.short_desc["de-DE"] = L"Neuer Name des Würfels";
        a.short_desc["fr-FR"] = L"Le nom nouveau du cube";
        a.short_desc["cs-CZ"] = L"New cube name";
        a.long_desc["en"] = L"New cube name.";
        a.long_desc["de-DE"] = L"Neuer Name des Würfels";
        a.long_desc["fr-FR"] = L"Le nom nouveau du cube.";
        a.long_desc["cs-CZ"] = L"New cube name.";
      
          fd.arg_pool["new_cube_name"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("old_cube_name");
          p.arg_keys.push_back("new_cube_name");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloCubeInfo";
        fd.c_name = "palo_cube_info";
        fd.short_desc["en"] = L"Shows cube info.";
        fd.short_desc["de-DE"] = L"Zeigt Würfelinformationen";
        fd.short_desc["fr-FR"] = L"Affiche des informations du cube.";
        fd.short_desc["cs-CZ"] = L"Shows cube info.";
        fd.long_desc["en"] = L"Shows cube info.";
        fd.long_desc["de-DE"] = L"Zeigt Würfelinformationen";
        fd.long_desc["fr-FR"] = L"Affiche des informations du cube.";
        fd.long_desc["cs-CZ"] = L"Shows cube info.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "database_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Name of the database.";
        a.short_desc["de-DE"] = L"Name der Datenbank";
        a.short_desc["fr-FR"] = L"Le nom de la base de donnée.";
        a.short_desc["cs-CZ"] = L"Name of the database.";
        a.long_desc["en"] = L"Name of the database.";
        a.long_desc["de-DE"] = L"Name der Datenbank";
        a.long_desc["fr-FR"] = L"Le nom de la base de donnée.";
        a.long_desc["cs-CZ"] = L"Name of the database.";
      
          fd.arg_pool["database_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Name of the cube.";
        a.short_desc["de-DE"] = L"Name des Würfels";
        a.short_desc["fr-FR"] = L"Le nom du cube.";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Name of the cube.";
        a.long_desc["de-DE"] = L"Name des Würfels";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["cube_name"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("database_name");
          p.arg_keys.push_back("cube_name");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloDimensionInfo";
        fd.c_name = "palo_dimension_info";
        fd.short_desc["en"] = L"Shows Dimensioninfo.";
        fd.short_desc["de-DE"] = L"Zeigt Dimensionsinformationen";
        fd.short_desc["fr-FR"] = L"Affiche info de la dimension.";
        fd.short_desc["cs-CZ"] = L"Shows Dimensioninfo.";
        fd.long_desc["en"] = L"Shows Dimensioninfo.";
        fd.long_desc["de-DE"] = L"Zeigt Dimensionsinformationen";
        fd.long_desc["fr-FR"] = L"Affiche info de la dimension.";
        fd.long_desc["cs-CZ"] = L"Shows Dimensioninfo.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "database_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Database name.";
        a.short_desc["de-DE"] = L"Name der Datenbank";
        a.short_desc["fr-FR"] = L"Nom de la base de données.";
        a.short_desc["cs-CZ"] = L"Database name.";
        a.long_desc["en"] = L"Name of the database.";
        a.long_desc["de-DE"] = L"Name der Datenbank";
        a.long_desc["fr-FR"] = L"Name of the database";
        a.long_desc["cs-CZ"] = L"Název databáze.";
      
          fd.arg_pool["database_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimensionname";
        a.short_desc["de-DE"] = L"Name der Dimension";
        a.short_desc["fr-FR"] = L"Nom de la dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Název dimenze";
      
          fd.arg_pool["dimension_name"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("database_name");
          p.arg_keys.push_back("dimension_name");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloRemoveConnection";
        fd.c_name = "palo_remove_connection";
        
        fd.xl_doc.xl_name = "PALO.REMOVE_CONNECTION";
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 0;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Remove connection.";
        fd.short_desc["de-DE"] = L"Trennt die Verbindung";
        fd.short_desc["fr-FR"] = L"Couper la connexion.";
        fd.short_desc["cs-CZ"] = L"Remove connection.";
        fd.long_desc["en"] = L"Remove connection.";
        fd.long_desc["de-DE"] = L"Trennt die Verbindung";
        fd.long_desc["fr-FR"] = L"Couper la connexion.";
        fd.long_desc["cs-CZ"] = L"Remove connection.";
        {
          ArgumentDocumentation a;
    
          a.name = "cname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Connection Name";
        a.short_desc["de-DE"] = L"Verbindungsname";
        a.short_desc["fr-FR"] = L"Nom de la connexion";
        a.short_desc["cs-CZ"] = L"Connection Name";
        a.long_desc["en"] = L"Connection Name";
        a.long_desc["de-DE"] = L"Verbindungsname";
        a.long_desc["fr-FR"] = L"Nom de la connexion";
        a.long_desc["cs-CZ"] = L"Connection Name";
      
          fd.arg_pool["cname"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("cname");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListDescendants";
        fd.c_name = "palo_element_list_descendants";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_DESCENDANTS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns all childs and grandchilds";
        fd.short_desc["de-DE"] = L"Listet alle Kinder sowie Kindeskinder auf";
        fd.short_desc["fr-FR"] = L"Liste tous les descendants.";
        fd.short_desc["cs-CZ"] = L"Vrátí všechny děti a vnoučata.";
        fd.long_desc["en"] = L"Returns all childs and grandchilds";
        fd.long_desc["de-DE"] = L"Listet alle Kinder sowie Kindeskinder auf";
        fd.long_desc["fr-FR"] = L"Liste tous les descendants.";
        fd.long_desc["cs-CZ"] = L"Vrátí všechny děti a vnoučata.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Dimension";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Element";
        a.long_desc["de-DE"] = L"Elementname";
        a.long_desc["fr-FR"] = L"Élément";
        a.long_desc["cs-CZ"] = L"Prvek";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementListAncestors";
        fd.c_name = "palo_element_list_ancestors";
        
        fd.xl_doc.xl_name = "PALO.ELEMENT_LIST_ANCESTORS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns all ancestors of the given element.";
        fd.short_desc["de-DE"] = L"Listet alle Ahnen (Elternelemente aller Stufen) des angegeben Elements auf";
        fd.short_desc["fr-FR"] = L"Listes de tous les ancêtres de l'élément spécifié";
        fd.short_desc["cs-CZ"] = L"Vrátí všechny potomky určeného prvku.";
        fd.long_desc["en"] = L"Returns all ancestors of the given element.";
        fd.long_desc["de-DE"] = L"Listet alle Ahnen (Elternelemente aller Stufen) des angegeben Elements auf";
        fd.long_desc["fr-FR"] = L"Listes de tous les ancêtres de l'élément spécifié";
        fd.long_desc["cs-CZ"] = L"Vrátí všechny potomky určeného prvku.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Dimension";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Element";
        a.long_desc["de-DE"] = L"Elementname";
        a.long_desc["fr-FR"] = L"Élément";
        a.long_desc["cs-CZ"] = L"Prvek";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Prázdný řetězec";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetCubeId";
        fd.c_name = "palo_get_cube_id";
        fd.short_desc["en"] = L"FPaloGetCubeId";
        fd.short_desc["de-DE"] = L"Liefert die ID des Würfels";
        fd.short_desc["fr-FR"] = L"FPaloGetCubeId";
        fd.short_desc["cs-CZ"] = L"FPaloGetCubeId";
        fd.long_desc["en"] = L"FPaloGetCubeId";
        fd.long_desc["de-DE"] = L"Liefert die ID des Würfels";
        fd.long_desc["fr-FR"] = L"FPaloGetCubeId";
        fd.long_desc["cs-CZ"] = L"FPaloGetCubeId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetCubeName";
        fd.c_name = "palo_get_cube_name";
        fd.short_desc["en"] = L"FPaloGetCubeName";
        fd.short_desc["de-DE"] = L"Liefert den Namen des Würfels";
        fd.short_desc["fr-FR"] = L"FPaloGetCubeName";
        fd.short_desc["cs-CZ"] = L"FPaloGetCubeName";
        fd.long_desc["en"] = L"FPaloGetCubeName";
        fd.long_desc["de-DE"] = L"Liefert den Namen des Würfels";
        fd.long_desc["fr-FR"] = L"FPaloGetCubeName";
        fd.long_desc["cs-CZ"] = L"FPaloGetCubeName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel";
        a.long_desc["fr-FR"] = L"Le nom du cube.";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetElementId";
        fd.c_name = "palo_get_element_id";
        fd.short_desc["en"] = L"FPaloGetElementId";
        fd.short_desc["de-DE"] = L"Liefert die ID des Elements";
        fd.short_desc["fr-FR"] = L"FPaloGetElementId";
        fd.short_desc["cs-CZ"] = L"FPaloGetElementId";
        fd.long_desc["en"] = L"FPaloGetElementId";
        fd.long_desc["de-DE"] = L"Liefert die ID des Elements";
        fd.long_desc["fr-FR"] = L"FPaloGetElementId";
        fd.long_desc["cs-CZ"] = L"FPaloGetElementId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Element";
        a.long_desc["de-DE"] = L"Elementname";
        a.long_desc["fr-FR"] = L"Élément";
        a.long_desc["cs-CZ"] = L"Prvek";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetElementName";
        fd.c_name = "palo_get_element_name";
        fd.short_desc["en"] = L"FPaloGetElementName";
        fd.short_desc["de-DE"] = L"Liefert den Namen des Elements";
        fd.short_desc["fr-FR"] = L"FPaloGetElementName";
        fd.short_desc["cs-CZ"] = L"FPaloGetElementName";
        fd.long_desc["en"] = L"FPaloGetElementName";
        fd.long_desc["de-DE"] = L"Liefert den Namen des Elements";
        fd.long_desc["fr-FR"] = L"FPaloGetElementName";
        fd.long_desc["cs-CZ"] = L"FPaloGetElementName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Element";
        a.short_desc["de-DE"] = L"Element";
        a.short_desc["fr-FR"] = L"Élément";
        a.short_desc["cs-CZ"] = L"Prvek";
        a.long_desc["en"] = L"Element";
        a.long_desc["de-DE"] = L"Elementname";
        a.long_desc["fr-FR"] = L"Élément";
        a.long_desc["cs-CZ"] = L"Prvek";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Element");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetDimensionId";
        fd.c_name = "palo_get_dimension_id";
        fd.short_desc["en"] = L"FPaloGetDimensionId";
        fd.short_desc["de-DE"] = L"Liefert die ID der Dimension";
        fd.short_desc["fr-FR"] = L"FPaloGetDimensionId";
        fd.short_desc["cs-CZ"] = L"FPaloGetDimensionId";
        fd.long_desc["en"] = L"FPaloGetDimensionId";
        fd.long_desc["de-DE"] = L"Liefert die ID der Dimension";
        fd.long_desc["fr-FR"] = L"FPaloGetDimensionId";
        fd.long_desc["cs-CZ"] = L"FPaloGetDimensionId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetDimensionName";
        fd.c_name = "palo_get_dimension_name";
        fd.short_desc["en"] = L"FPaloGetDimensionName";
        fd.short_desc["de-DE"] = L"Liefert den Namen der Dimension";
        fd.short_desc["fr-FR"] = L"FPaloGetDimensionName";
        fd.short_desc["cs-CZ"] = L"FPaloGetDimensionName";
        fd.long_desc["en"] = L"FPaloGetDimensionName";
        fd.long_desc["de-DE"] = L"Liefert den Namen der Dimension";
        fd.long_desc["fr-FR"] = L"FPaloGetDimensionName";
        fd.long_desc["cs-CZ"] = L"FPaloGetDimensionName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Dimenze";
        a.long_desc["en"] = L"Dimension";
        a.long_desc["de-DE"] = L"Dimensionsname";
        a.long_desc["fr-FR"] = L"Le nom de la dimension.";
        a.long_desc["cs-CZ"] = L"Dimenze";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloElementAlias";
        fd.c_name = "palo_ealias";
        
        fd.xl_doc.xl_name = "PALO.EALIAS";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Get a list of all elements with the matching alias.";
        fd.short_desc["de-DE"] = L"Liefert eine Liste mit allen Elementen die das angegebene Alias haben";
        fd.short_desc["fr-FR"] = L"Retourne une liste contenant tous les éléments ont l'alias spécifié.";
        fd.short_desc["cs-CZ"] = L"Získat seznam všech prvků, které odpovídají zadanému aliasu.";
        fd.long_desc["en"] = L"Get a list of all elements with the matching alias.";
        fd.long_desc["de-DE"] = L"Liefert eine Liste mit allen Elementen die das angegebene Alias haben";
        fd.long_desc["fr-FR"] = L"Retourne une liste contenant tous les éléments ont l'alias spécifié.";
        fd.long_desc["cs-CZ"] = L"Získat seznam všech prvků, které odpovídají zadanému aliasu.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Dimension";
        a.short_desc["de-DE"] = L"Dimension";
        a.short_desc["fr-FR"] = L"Dimension";
        a.short_desc["cs-CZ"] = L"Název dimenze.";
        a.long_desc["en"] = L"Name of the dimension.";
        a.long_desc["de-DE"] = L"Name der Dimension.";
        a.long_desc["fr-FR"] = L"Nom de la dimension";
        a.long_desc["cs-CZ"] = L"Název dimenze.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Attribute";
        a.short_desc["de-DE"] = L"Attribut";
        a.short_desc["fr-FR"] = L"Attribut";
        a.short_desc["cs-CZ"] = L"Název atribuce.";
        a.long_desc["en"] = L"Name of the Attribute.";
        a.long_desc["de-DE"] = L"Name des Attributs";
        a.long_desc["fr-FR"] = L"Nom  de l'attribut.";
        a.long_desc["cs-CZ"] = L"Název atribuce.";
      
          fd.arg_pool["Attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "AliasValue";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Alias";
        a.short_desc["de-DE"] = L"Alias";
        a.short_desc["fr-FR"] = L"Alias";
        a.short_desc["cs-CZ"] = L"Aliasu";
        a.long_desc["en"] = L"Name of the alias you want to look for.";
        a.long_desc["de-DE"] = L"Name des Alias";
        a.long_desc["fr-FR"] = L"Nom de l'alias pour qui doit être recherchée";
        a.long_desc["cs-CZ"] = L"Název aliasu, který chcete vyhledat.";
      
          fd.arg_pool["AliasValue"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Index";
        a.short_desc["de-DE"] = L"Index";
        a.short_desc["fr-FR"] = L"Index";
        a.short_desc["cs-CZ"] = L"Index";
        a.long_desc["en"] = L"Index of the element in the result, which you want to show. 0 or empty for all elements.";
        a.long_desc["de-DE"] = L"Index des Ergebniselements, das angezeigt werden soll. 0 oder leer für alle Elemente";
        a.long_desc["fr-FR"] = L"Index de l'élément qui doit être affiché. 0 ou vide pour tous les éléments.";
        a.long_desc["cs-CZ"] = L"Index prvku ve výsledku, který chcete zobrazit. 0 nebo prázdné: všechny prvky.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Empty String";
        a.short_desc["de-DE"] = L"Leerer String";
        a.short_desc["fr-FR"] = L"Chaîne vide";
        a.short_desc["cs-CZ"] = L"Prázdný řetězec";
        a.long_desc["en"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = L"WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = L"Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
        a.long_desc["cs-CZ"] = L"Enter TRUE to suppress error messages. Otherwise, leave blank.";
      
          fd.arg_pool["Empty String"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Dimension");
          p.arg_keys.push_back("Attribute");
          p.arg_keys.push_back("AliasValue");
          p.arg_keys.push_back("Index");
          p.arg_keys.push_back("Empty String");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloExpandTypeSelf";
        fd.c_name = "palo_agr_self";
        
        fd.xl_doc.xl_name = "PALO.AGR.SELF";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Helper function";
        fd.short_desc["de-DE"] = L"Hilfsfunktion";
        fd.short_desc["fr-FR"] = L"Fonction d'assistance ";
        fd.short_desc["cs-CZ"] = L"Helper function";
        fd.long_desc["en"] = L"Helper function : return value for aggregation expand type SELF.";
        fd.long_desc["de-DE"] = L"Hilfsfunktion : Liefert Wert für Aggregation Expand Type SELF.";
        fd.long_desc["fr-FR"] = L"Fonction d'assistance : Retourne la valeur pour l'agrégation expand type SELF. ";
        fd.long_desc["cs-CZ"] = L"Helper function : return value for aggregation expand type SELF.";
        {
          ArgumentDocumentation a;
    
          a.name = "Dummy";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"unused";
        a.short_desc["de-DE"] = L"unbenutzt";
        a.short_desc["fr-FR"] = L"pas utilisé ";
        a.short_desc["cs-CZ"] = L"unused";
        a.long_desc["en"] = L"optional";
        a.long_desc["de-DE"] = L"optional";
        a.long_desc["fr-FR"] = L"optionnel ";
        a.long_desc["cs-CZ"] = L"optional";
      
          fd.arg_pool["Dummy"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Dummy");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloExpandTypeChildren";
        fd.c_name = "palo_agr_children";
        
        fd.xl_doc.xl_name = "PALO.AGR.CHILDREN";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Helper function.";
        fd.short_desc["de-DE"] = L"Hilfsfunktion.";
        fd.short_desc["fr-FR"] = L"Fonction d'assistance ";
        fd.short_desc["cs-CZ"] = L"Helper function.";
        fd.long_desc["en"] = L"Helper function : return value for aggregation expand type CHILDREN.";
        fd.long_desc["de-DE"] = L"Hilfsfunktion : Liefert Wert für Aggregation Expand Type CHILDREN.";
        fd.long_desc["fr-FR"] = L"Fonction d'assistance : Retourne la valeur pour l'agrégation expand type CHILDREN. ";
        fd.long_desc["cs-CZ"] = L"Helper function : return value for aggregation expand type CHILDREN.";
        {
          ArgumentDocumentation a;
    
          a.name = "Dummy";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"unused";
        a.short_desc["de-DE"] = L"unbenutzt";
        a.short_desc["fr-FR"] = L"pas utilisé ";
        a.short_desc["cs-CZ"] = L"unused";
        a.long_desc["en"] = L"optional";
        a.long_desc["de-DE"] = L"optional";
        a.long_desc["fr-FR"] = L"optionnel ";
        a.long_desc["cs-CZ"] = L"optional";
      
          fd.arg_pool["Dummy"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Dummy");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloExpandTypeLeaves";
        fd.c_name = "palo_agr_leaves";
        
        fd.xl_doc.xl_name = "PALO.AGR.LEAVES";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Helper function.";
        fd.short_desc["de-DE"] = L"Hilfsfunktion.";
        fd.short_desc["fr-FR"] = L"Fonction d'assistance ";
        fd.short_desc["cs-CZ"] = L"Helper function.";
        fd.long_desc["en"] = L"Helper function : return value for aggregation expand type LEAVES.";
        fd.long_desc["de-DE"] = L"Hilfsfunktion : Liefert Wert für Aggregation Expand Type LEAVES.";
        fd.long_desc["fr-FR"] = L"Fonction d'assistance : Retourne la valeur pour l'agrégation expand type LEAVES. ";
        fd.long_desc["cs-CZ"] = L"Helper function : return value for aggregation expand type LEAVES.";
        {
          ArgumentDocumentation a;
    
          a.name = "Dummy";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"unused";
        a.short_desc["de-DE"] = L"unbenutzt";
        a.short_desc["fr-FR"] = L"pas utilisé ";
        a.short_desc["cs-CZ"] = L"unused";
        a.long_desc["en"] = L"optional";
        a.long_desc["de-DE"] = L"optional";
        a.long_desc["fr-FR"] = L"optionnel ";
        a.long_desc["cs-CZ"] = L"optional";
      
          fd.arg_pool["Dummy"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Dummy");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloCoordinatesToArray";
        fd.c_name = "palo_coord";
        
        fd.xl_doc.xl_name = "PALO.COORD";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Helper function.";
        fd.short_desc["de-DE"] = L"Hilfsfunktion.";
        fd.short_desc["fr-FR"] = L"Fonction d'assistance ";
        fd.short_desc["cs-CZ"] = L"Helper function.";
        fd.long_desc["en"] = L"Helper function : return arguments as one string array.";
        fd.long_desc["de-DE"] = L"Hilfsfunktion : Liefert Argumente als ein String Array zurück.";
        fd.long_desc["fr-FR"] = L"Helper function : return arguments as one string array..";
        fd.long_desc["cs-CZ"] = L"Helper function : return arguments as one string array.";
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinate";
        a.short_desc["de-DE"] = L"Koordinate";
        a.short_desc["fr-FR"] = L"Coordonnée ";
        a.short_desc["cs-CZ"] = L"Koordináta";
        a.long_desc["en"] = L"The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = L"Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = L"Les coordonnées sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube.";
        a.long_desc["cs-CZ"] = L"The coordinates are specified in the order as in the cube.";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Coordinates");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloExpandTypesToArray";
        fd.c_name = "palo_expandtype";
        
        fd.xl_doc.xl_name = "PALO.EXPANDTYPE";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Helper function.";
        fd.short_desc["de-DE"] = L"Hilfsfunktion.";
        fd.short_desc["fr-FR"] = L"Fonction d'assistance ";
        fd.short_desc["cs-CZ"] = L"Helper function.";
        fd.long_desc["en"] = L"Helper function : return arguments as one integer array.";
        fd.long_desc["de-DE"] = L"Hilfsfunktion : Liefert Argumente als ein Integer Array zurück.";
        fd.long_desc["fr-FR"] = L"Helper function : return arguments as one integer array..";
        fd.long_desc["cs-CZ"] = L"Helper function : return arguments as one integer array.";
        {
          ArgumentDocumentation a;
    
          a.name = "ExpandType";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"integer";
        a.short_desc["de-DE"] = L"Ganzzahl";
        a.short_desc["fr-FR"] = L"entier ";
        a.short_desc["cs-CZ"] = L"integer";
        a.long_desc["en"] = L"integer";
        a.long_desc["de-DE"] = L"Ganzzahl";
        a.long_desc["fr-FR"] = L"entier ";
        a.long_desc["cs-CZ"] = L"integer";
      
          fd.arg_pool["ExpandType"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("ExpandType");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAggregationSum";
        fd.c_name = "palo_data_sum";
        
        fd.xl_doc.xl_name = "PALO.DATA.SUM";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the max value of a cell range from the cube. ";
        fd.short_desc["de-DE"] = L"Liefert den Summenwert eines Zellbereichs aus dem Würfel. ";
        fd.short_desc["fr-FR"] = L"Renvoie la somme d'une plage de cellules à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Returns the max value of a cell range from the cube. ";
        fd.long_desc["en"] = L"Returns the sum value of a cell range from the cube. ";
        fd.long_desc["de-DE"] = L"Liefert den Summenwert eines Zellbereichs aus dem Würfel. ";
        fd.long_desc["fr-FR"] = L"Renvoie la somme d'une plage de cellules à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Returns the sum value of a cell range from the cube. ";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinates";
        a.short_desc["de-DE"] = L"Koordinaten";
        a.short_desc["fr-FR"] = L"Coordonnées ";
        a.short_desc["cs-CZ"] = L"Koordináty";
        a.long_desc["en"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
        a.long_desc["de-DE"] = L"Koordinaten (als Array) werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind (PALO.COORD benutzen). ";
        a.long_desc["fr-FR"] = L"Les coordonnées (as array) sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube (utilize PALO.COORD). ";
        a.long_desc["cs-CZ"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Expandtypes";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Expandtypes";
        a.short_desc["de-DE"] = L"Erweiterungstypen ";
        a.short_desc["fr-FR"] = L"Types d'expansion ";
        a.short_desc["cs-CZ"] = L"Expandtypes";
        a.long_desc["en"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
        a.long_desc["de-DE"] = L"Erweiterungstypen als Array (PALO.EXPANDTYPE benutzen). ";
        a.long_desc["fr-FR"] = L"Types d'expansion comme un tableau (Utilisez PALO.EXPANDTYPE). ";
        a.long_desc["cs-CZ"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
      
          fd.arg_pool["Expandtypes"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
          p.arg_keys.push_back("Expandtypes");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAggregationAvg";
        fd.c_name = "palo_data_avg";
        
        fd.xl_doc.xl_name = "PALO.DATA.AVG";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the average value of a cell range from the cube. ";
        fd.short_desc["de-DE"] = L"Liefert den Durchschnittswert eines Zellbereichs aus dem Würfel. ";
        fd.short_desc["fr-FR"] = L"Renvoie la valeur moyenne d'une plage de cellules à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Returns the average value of a cell range from the cube. ";
        fd.long_desc["en"] = L"Returns the average value of a cell range from the cube. ";
        fd.long_desc["de-DE"] = L"Liefert den Durchschnittswert eines Zellbereichs aus dem Würfel. ";
        fd.long_desc["fr-FR"] = L"Renvoie la valeur moyenne d'une plage de cellules à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Returns the average value of a cell range from the cube. ";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinates";
        a.short_desc["de-DE"] = L"Koordinaten";
        a.short_desc["fr-FR"] = L"Coordonnées ";
        a.short_desc["cs-CZ"] = L"Coordinates";
        a.long_desc["en"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
        a.long_desc["de-DE"] = L"Koordinaten (als Array) werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind (PALO.COORD benutzen). ";
        a.long_desc["fr-FR"] = L"Les coordonnées (as array) sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube (utilize PALO.COORD). ";
        a.long_desc["cs-CZ"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Expandtypes";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Expandtypes";
        a.short_desc["de-DE"] = L"Erweiterungstypen ";
        a.short_desc["fr-FR"] = L"Types d'expansion ";
        a.short_desc["cs-CZ"] = L"Expandtypes";
        a.long_desc["en"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
        a.long_desc["de-DE"] = L"Erweiterungstypen als Array (PALO.EXPANDTYPE benutzen). ";
        a.long_desc["fr-FR"] = L"Types d'expansion comme un tableau (Utilisez PALO.EXPANDTYPE). ";
        a.long_desc["cs-CZ"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
      
          fd.arg_pool["Expandtypes"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
          p.arg_keys.push_back("Expandtypes");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAggregationCount";
        fd.c_name = "palo_data_count";
        
        fd.xl_doc.xl_name = "PALO.DATA.CNT";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the number of cells of a cell range from the cube. ";
        fd.short_desc["de-DE"] = L"Liefert die Zellenanzahl eines Zellbereichs aus dem Würfel. ";
        fd.short_desc["fr-FR"] = L"Renvoie le nombre de cellules d'une plage de cellules à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Returns the number of cells of a cell range from the cube. ";
        fd.long_desc["en"] = L"Returns the count value of an area of cells from the cube. ";
        fd.long_desc["de-DE"] = L"Liefert die Zellenanzahl eines Zellbereichs aus dem Würfel. ";
        fd.long_desc["fr-FR"] = L"Renvoie le nombre de cellules d'une plage de cellules à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Returns the count value of an area of cells from the cube. ";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinates";
        a.short_desc["de-DE"] = L"Koordinaten";
        a.short_desc["fr-FR"] = L"Coordonnées ";
        a.short_desc["cs-CZ"] = L"Koordináty";
        a.long_desc["en"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
        a.long_desc["de-DE"] = L"Koordinaten (als Array) werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind (PALO.COORD benutzen). ";
        a.long_desc["fr-FR"] = L"Les coordonnées (as array) sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube (utilize PALO.COORD). ";
        a.long_desc["cs-CZ"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Expandtypes";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Expandtypes";
        a.short_desc["de-DE"] = L"Erweiterungstypen ";
        a.short_desc["fr-FR"] = L"Types d'expansion ";
        a.short_desc["cs-CZ"] = L"Expandtypes";
        a.long_desc["en"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
        a.long_desc["de-DE"] = L"Erweiterungstypen als Array (PALO.EXPANDTYPE benutzen). ";
        a.long_desc["fr-FR"] = L"Types d'expansion comme un tableau (Utilisez PALO.EXPANDTYPE). ";
        a.long_desc["cs-CZ"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
      
          fd.arg_pool["Expandtypes"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
          p.arg_keys.push_back("Expandtypes");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAggregationMax";
        fd.c_name = "palo_data_max";
        
        fd.xl_doc.xl_name = "PALO.DATA.MAX";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the max value of a cell range from the cube. ";
        fd.short_desc["de-DE"] = L"Liefert den Maximalwert eines Zellbereichs aus dem Würfel. ";
        fd.short_desc["fr-FR"] = L"Renvoie la valeur max d'une plage de cellules à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Returns the max value of a cell range from the cube. ";
        fd.long_desc["en"] = L"Returns the max value of a cell range from the cube. ";
        fd.long_desc["de-DE"] = L"Liefert den Maximalwert eines Zellbereichs aus dem Würfel. ";
        fd.long_desc["fr-FR"] = L"Renvoie la valeur max d'une plage de cellules à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Returns the max value of a cell range from the cube. ";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinates";
        a.short_desc["de-DE"] = L"Koordinaten";
        a.short_desc["fr-FR"] = L"Coordonnées ";
        a.short_desc["cs-CZ"] = L"Koordináty";
        a.long_desc["en"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
        a.long_desc["de-DE"] = L"Koordinaten (als Array) werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind (PALO.COORD benutzen). ";
        a.long_desc["fr-FR"] = L"Les coordonnées (as array) sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube (utilize PALO.COORD). ";
        a.long_desc["cs-CZ"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Expandtypes";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Expandtypes";
        a.short_desc["de-DE"] = L"Erweiterungstypen ";
        a.short_desc["fr-FR"] = L"Types d'expansion ";
        a.short_desc["cs-CZ"] = L"Expandtypes";
        a.long_desc["en"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
        a.long_desc["de-DE"] = L"Erweiterungstypen als Array (PALO.EXPANDTYPE benutzen). ";
        a.long_desc["fr-FR"] = L"Types d'expansion comme un tableau (Utilisez PALO.EXPANDTYPE). ";
        a.long_desc["cs-CZ"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
      
          fd.arg_pool["Expandtypes"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
          p.arg_keys.push_back("Expandtypes");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloGetdataAggregationMin";
        fd.c_name = "palo_data_min";
        
        fd.xl_doc.xl_name = "PALO.DATA.MIN";
        fd.xl_doc.xl_special = (bool)0;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)1;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = L"Returns the max value of a cell range from the cube. ";
        fd.short_desc["de-DE"] = L"Liefert den Minimalwert eines Zellbereichs aus dem Würfel. ";
        fd.short_desc["fr-FR"] = L"Renvoie la valeur min d'une plage de cellules à partir du cube. ";
        fd.short_desc["cs-CZ"] = L"Returns the max value of a cell range from the cube. ";
        fd.long_desc["en"] = L"Returns the min value of a cell range from the cube. ";
        fd.long_desc["de-DE"] = L"Liefert den Minimalwert eines Zellbereichs aus dem Würfel. ";
        fd.long_desc["fr-FR"] = L"Renvoie la valeur min d'une plage de cellules à partir du cube. ";
        fd.long_desc["cs-CZ"] = L"Returns the min value of a cell range from the cube. ";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Server/Database";
        a.short_desc["de-DE"] = L"Server/Datenbank";
        a.short_desc["fr-FR"] = L"Serveur/Base de données ";
        a.short_desc["cs-CZ"] = L"Server/Databáze";
        a.long_desc["en"] = L"Server/Database";
        a.long_desc["de-DE"] = L"Server/Datenbank";
        a.long_desc["fr-FR"] = L"Serveur/Base de données ";
        a.long_desc["cs-CZ"] = L"Server/Databáze";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Cube";
        a.short_desc["de-DE"] = L"Würfel ";
        a.short_desc["fr-FR"] = L"Cube";
        a.short_desc["cs-CZ"] = L"Kostka";
        a.long_desc["en"] = L"Cube";
        a.long_desc["de-DE"] = L"Würfel ";
        a.long_desc["fr-FR"] = L"Nom du cube qui contient l’élément souhaité. ";
        a.long_desc["cs-CZ"] = L"Název kostky";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Coordinates";
        a.short_desc["de-DE"] = L"Koordinaten";
        a.short_desc["fr-FR"] = L"Coordonnées ";
        a.short_desc["cs-CZ"] = L"Koordináty";
        a.long_desc["en"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
        a.long_desc["de-DE"] = L"Koordinaten (als Array) werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind (PALO.COORD benutzen). ";
        a.long_desc["fr-FR"] = L"Les coordonnées (as array) sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube (utilize PALO.COORD). ";
        a.long_desc["cs-CZ"] = L"The coordinates (as array) are specified in the order as in the cube (use PALO.COORD).";
      
          fd.arg_pool["Coordinates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Expandtypes";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = L"Expandtypes";
        a.short_desc["de-DE"] = L"Erweiterungstypen ";
        a.short_desc["fr-FR"] = L"Types d'expansion ";
        a.short_desc["cs-CZ"] = L"Expandtypes";
        a.long_desc["en"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
        a.long_desc["de-DE"] = L"Erweiterungstypen als Array (PALO.EXPANDTYPE benutzen). ";
        a.long_desc["fr-FR"] = L"Types d'expansion comme un tableau (Utilisez PALO.EXPANDTYPE). ";
        a.long_desc["cs-CZ"] = L"Expandtypes as array (use PALO.EXPANDTYPE).";
      
          fd.arg_pool["Expandtypes"] = a;
        }
    
        {
          PrototypeDocumentation p;
    
          p.arg_keys.push_back("Server/Database");
          p.arg_keys.push_back("Cube");
          p.arg_keys.push_back("Coordinates");
          p.arg_keys.push_back("Expandtypes");
      
          fd.prototypes.push_back(p);
        } 
    
        functions.push_back(fd);
      }
    