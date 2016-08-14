
      {
        FunctionDocumentation fd;
    
        fd.name = "FPaloInit";
        fd.c_name = "palo_init";
        fd.short_desc["en"] = "Connects to a PALO server.";
        fd.short_desc["de-DE"] = "Verbindet mit einem PALO Server";
        fd.short_desc["fr-FR"] = "Se connecte avec un serveur Palo.";
        fd.long_desc["en"] = "Connects to a PALO server.";
        fd.long_desc["de-DE"] = "Verbindet mit einem PALO Server";
        fd.long_desc["fr-FR"] = "Se connecte avec un serveur Palo.";
        {
          ArgumentDocumentation a;
    
          a.name = "hostname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Hostname";
        a.short_desc["de-DE"] = "Hostname";
        a.short_desc["fr-FR"] = "Le nom de l'hôte.";
        a.long_desc["en"] = "Name of the host. Sample: localhost.";
        a.long_desc["de-DE"] = "Hostname.  Beispiel: localhost";
        a.long_desc["fr-FR"] = "Le nom de l'hôte. Sample: localhost";
      
          fd.arg_pool["hostname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "port";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Port";
        a.short_desc["de-DE"] = "Port";
        a.short_desc["fr-FR"] = "Port";
        a.long_desc["en"] = "Port";
        a.long_desc["de-DE"] = "Port";
        a.long_desc["fr-FR"] = "Port";
      
          fd.arg_pool["port"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "username";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Username";
        a.short_desc["de-DE"] = "Benutzername";
        a.short_desc["fr-FR"] = "Nom d'utilisateur";
        a.long_desc["en"] = "Username";
        a.long_desc["de-DE"] = "Benutzername";
        a.long_desc["fr-FR"] = "Nom d'utilisateur";
      
          fd.arg_pool["username"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "pw_hash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Pw_hash";
        a.short_desc["de-DE"] = "Pw_hash";
        a.short_desc["fr-FR"] = "Pw_Codage";
        a.long_desc["en"] = "Pw_hash";
        a.long_desc["de-DE"] = "Pw_hash";
        a.long_desc["fr-FR"] = "Pw_Codage";
      
          fd.arg_pool["pw_hash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "forcecheck";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("bool");
    
        a.short_desc["en"] = "";
        a.short_desc["de-DE"] = "";
        a.short_desc["fr-FR"] = "";
        a.long_desc["en"] = "";
        a.long_desc["de-DE"] = "";
        a.long_desc["fr-FR"] = "";
      
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
        fd.short_desc["en"] = "Registers a PALO server for use with the PALO Client Library.";
        fd.short_desc["de-DE"] = "Registriert einen PALO-Server für die Benutzung mit der PALO-Client-Bibliothek";
        fd.short_desc["fr-FR"] = "Enregistre un serveur PALO pour l' utilisation avec la bibliothèque PALO Client.";
        fd.long_desc["en"] = "Registers a PALO server for use with the PALO Client Library.";
        fd.long_desc["de-DE"] = "Registriert einen PALO-Server für die Benutzung mit der PALO-Client-Bibliothek";
        fd.long_desc["fr-FR"] = "Enregistre un serveur PALO pour l'utilisation avec la bibliothèque PALO Client.";
        {
          ArgumentDocumentation a;
    
          a.name = "localname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Localname";
        a.short_desc["de-DE"] = "Lokaler Name";
        a.short_desc["fr-FR"] = "Le nom local";
        a.long_desc["en"] = "Name of the server (localhost).";
        a.long_desc["de-DE"] = "Name des Servers (localhost)";
        a.long_desc["fr-FR"] = "Le nom du serveur (localhost)";
      
          fd.arg_pool["localname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "hostname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Hostname";
        a.short_desc["de-DE"] = "Hostname";
        a.short_desc["fr-FR"] = "Le nom de l'hôte.";
        a.long_desc["en"] = "Host IP (sample: 127.0.0.1)";
        a.long_desc["de-DE"] = "Host IP (Beispiel: 127.0.0.1)";
        a.long_desc["fr-FR"] = "Host_IP (exemple:127.0.0.1)";
      
          fd.arg_pool["hostname"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "port";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Port";
        a.short_desc["de-DE"] = "Port";
        a.short_desc["fr-FR"] = "Port";
        a.long_desc["en"] = "Port (sample: 7777)";
        a.long_desc["de-DE"] = "Port (Beispiel: 7777)";
        a.long_desc["fr-FR"] = "Port (exemple:7777)";
      
          fd.arg_pool["port"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "username";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Username";
        a.short_desc["de-DE"] = "Benutzername";
        a.short_desc["fr-FR"] = "Nom d'utilisateur";
        a.long_desc["en"] = "Username";
        a.long_desc["de-DE"] = "Benutzername";
        a.long_desc["fr-FR"] = "Nom d'utilisateur";
      
          fd.arg_pool["username"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "pw_hash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Pw_hash";
        a.short_desc["de-DE"] = "Pw_hash";
        a.short_desc["fr-FR"] = "Pw_codage";
        a.long_desc["en"] = "Pw_hash";
        a.long_desc["de-DE"] = "Pw_hash";
        a.long_desc["fr-FR"] = "Pw_codage";
      
          fd.arg_pool["pw_hash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dologin";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("bool");
    
        a.short_desc["en"] = "";
        a.short_desc["de-DE"] = "";
        a.short_desc["fr-FR"] = "";
        a.long_desc["en"] = "";
        a.long_desc["de-DE"] = "";
        a.long_desc["fr-FR"] = "";
      
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
        fd.short_desc["en"] = "Returns the name of the preceding element in the dimension";
        fd.short_desc["de-DE"] = "Liefert den Namen des in der Dimension davorstehenden Elementes";
        fd.short_desc["fr-FR"] = "Indique le nom de l’élément antéposé.";
        fd.long_desc["en"] = "Returns the name of the preceding element in the dimension";
        fd.long_desc["de-DE"] = "Liefert den Namen des in der Dimension davorstehenden Elementes";
        fd.long_desc["fr-FR"] = "Indique le nom de l’élément antéposé d’une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Bse de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.The previous element of this element will be displayed.";
        a.long_desc["de-DE"] = "Als Parameter wird der Name des im Index folgenden Elementes angegeben. Es wird dann das im Index davorstehende Element ausgegeben";
        a.long_desc["fr-FR"] = "Nom de l’élément est indiqué en tant que paramètre, l’élément est indiqué dans la position antérieure.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the succeeding element in the dimension";
        fd.short_desc["de-DE"] = "Liefert den Namen des in der Dimension nachfolgenden Elementes";
        fd.short_desc["fr-FR"] = "Renvoie le nom de l’élément suivant dans la position.";
        fd.long_desc["en"] = "Returns the name of the succeeding element in the dimension";
        fd.long_desc["de-DE"] = "Liefert den Namen des in der Dimension nachfolgenden Elementes";
        fd.long_desc["fr-FR"] = "Renvoie le nom de l’élément suivant dans la position.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element. The next element of this element will be displayed.";
        a.long_desc["de-DE"] = "Als Parameter wird der Name des im Index vorangehenden Elementes angegeben. Es wird dann das im Index darauffolgende Element ausgegeben";
        a.long_desc["fr-FR"] = "Nom de l’élément est indiqué en tant que paramètre, l’élément suivant dans la position sera renvoyé.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the specified child element";
        fd.short_desc["de-DE"] = "Liefert den Namen des bestimmten Kindelementes";
        fd.short_desc["fr-FR"] = "Donne le nom de l’élément enfant défini.";
        fd.long_desc["en"] = "Returns the name of the specified child element";
        fd.long_desc["de-DE"] = "Liefert den Namen des bestimmten Kindelementes";
        fd.long_desc["fr-FR"] = "Donne le nom de l’élément enfant défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à indiquer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the parent element which contains the child element.";
        a.long_desc["de-DE"] = "Name des Elternelementes, welches das anzuzeigende Kindelement enthält";
        a.long_desc["fr-FR"] = "Nom de l’élément parent qui contient l’élément enfant.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Index number, that specifies the child element";
        a.long_desc["de-DE"] = "Indexnummer, die das Kindelement festlegt";
        a.long_desc["fr-FR"] = "Numéro de position qui définit l’élément enfant.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the specified child element";
        fd.short_desc["de-DE"] = "Liefert den Namen des bestimmten Kindelementes";
        fd.short_desc["fr-FR"] = "Retourne le nom de l'élément enfant spécifié.";
        fd.long_desc["en"] = "Returns the name of the specified child element";
        fd.long_desc["de-DE"] = "Liefert den Namen des bestimmten Kindelementes";
        fd.long_desc["fr-FR"] = "Retourne le nom de l'élément enfant spécifié.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ElementArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the parent element, which contains the child element.";
        a.long_desc["de-DE"] = "Name des Elternelementes, welches das anzuzeigende Kindelement enthält";
        a.long_desc["fr-FR"] = "Nom de l'élément parent qui contient l'élément enfant.";
      
          fd.arg_pool["ElementArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Typ";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Index number, that specifies the child element";
        a.long_desc["de-DE"] = "Indexnummer, die das Kindelement festlegt";
        a.long_desc["fr-FR"] = "Numéro d'index, qui spécifie l'enfant élément.";
      
          fd.arg_pool["Typ"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ChildrenArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
      
          fd.arg_pool["ChildrenArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "WeightArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
      
          fd.arg_pool["WeightArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "EmptyString";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
      
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
        fd.short_desc["en"] = "Returns the first element in the specified dimension";
        fd.short_desc["de-DE"] = "Liefert das erste Element der angegebenen Dimension";
        fd.short_desc["fr-FR"] = "Donne le premier élément dans la dimension/les éléments parent.";
        fd.long_desc["en"] = "Returns the first element in the specified dimension";
        fd.long_desc["de-DE"] = "Liefert das erste Element der angegebenen Dimension";
        fd.long_desc["fr-FR"] = "Donne le premier élément dans la dimension/les éléments parent.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the number of children of the specified element";
        fd.short_desc["de-DE"] = "Liefert die Anzahl der Kindelemente des angegebenen Elements";
        fd.short_desc["fr-FR"] = "Donne le nombre des éléments enfant à partir de l’élément consolidé défini.";
        fd.long_desc["en"] = "Returns the number of children of the specified element";
        fd.long_desc["de-DE"] = "Liefert die Anzahl der Kindelemente des angegebenen Elements";
        fd.long_desc["fr-FR"] = "Donne le nombre des éléments enfant à partir de l’élément consolidé défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément parent que contient l’élément enfant.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the number of elements in the specified dimension";
        fd.short_desc["de-DE"] = "Liefert die Anzahl der Elemente einer Dimension";
        fd.short_desc["fr-FR"] = "Donne le nombre d’éléments dans une dimension définie.";
        fd.long_desc["en"] = "Returns the number of elements in the specified dimension";
        fd.long_desc["de-DE"] = "Liefert die Anzahl der Elemente einer Dimension";
        fd.long_desc["fr-FR"] = "Donne le nombre d’éléments dans une dimension définie.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the position of the specified element in the dimension";
        fd.short_desc["de-DE"] = "Gibt die Position des beschriebenen Elements in der Dimension zurück";
        fd.short_desc["fr-FR"] = "Renvoie la position de l’élément indiqué dans la dimension.";
        fd.long_desc["en"] = "Returns the position of the specified element in the dimension";
        fd.long_desc["de-DE"] = "Gibt die Position des beschriebenen Elements in der Dimension zurück";
        fd.long_desc["fr-FR"] = "Renvoie la position de l’élément indiqué dans la dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element, whose index is to display.";
        a.long_desc["de-DE"] = "Name des Elementes, dessen Index angezeigt werden soll";
        a.long_desc["fr-FR"] = "Nom de l’élément dont la position doit être affichée.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Checks if a parent element contains the specified element as child element";
        fd.short_desc["de-DE"] = "Prüft, ob ein Elternelement ein bestimmtes Element als Kindelement enthält";
        fd.short_desc["fr-FR"] = "Vérifie si un élément consolidé contient l’élément indiqué.";
        fd.long_desc["en"] = "Checks if a parent element contains the specified element as child element";
        fd.long_desc["de-DE"] = "Prüft, ob ein Elternelement ein bestimmtes Element als Kindelement enthält";
        fd.long_desc["fr-FR"] = "Vérifie si un élément consolidé contient l’élément indiqué.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Parent Element";
        a.short_desc["de-DE"] = "Elternelement";
        a.short_desc["fr-FR"] = "Élément parent";
        a.long_desc["en"] = "Name of the parent element.";
        a.long_desc["de-DE"] = "Name des Elternelements";
        a.long_desc["fr-FR"] = "Nom de l’élément parent.";
      
          fd.arg_pool["Parent Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element, which is to be checked whether it is a child element.";
        a.long_desc["de-DE"] = "Name des Elementes, dass geprüft werden soll, ob es ein Kindelement ist";
        a.long_desc["fr-FR"] = "Nom de l’élément qui doit être vérifié s’il s’agit d’un élément enfant.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the element with the positionnumber INDEX (First element has positionnumber 1)";
        fd.short_desc["de-DE"] = "Liefert den Namen des Elementes mit der Positionsnummer INDEX (Erstes Element hat die Positions-Nr. 1)";
        fd.short_desc["fr-FR"] = "Renvoie le nom de l’élément à une position précise (la première position est 1).";
        fd.long_desc["en"] = "Returns the name of the element with the positionnumber INDEX (First element has positionnumber 1)";
        fd.long_desc["de-DE"] = "Liefert den Namen des Elementes mit der Positionsnummer INDEX (Erstes Element hat die Positions-Nr. 1)";
        fd.long_desc["fr-FR"] = "Renvoie le nom de l’élément à une position précise (la première position est 1).";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Index number, that specifies the position of the element in the dimension";
        a.long_desc["de-DE"] = "Indexnummer, welche die Position des Elements in der Dimension angibt";
        a.long_desc["fr-FR"] = "Numéro de position qui définit l’élément à partir de la dimension utilisée.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l'élément";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Attribute";
        a.short_desc["de-DE"] = "Attribut";
        a.short_desc["fr-FR"] = "Attribut";
        a.long_desc["en"] = "Name of the attribute.";
        a.long_desc["de-DE"] = "Name des Attributes";
        a.long_desc["fr-FR"] = "Nom de l'attribut";
      
          fd.arg_pool["Attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Reserved";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Reserved";
        a.short_desc["de-DE"] = "Reserviert";
        a.short_desc["fr-FR"] = "Réservé";
        a.long_desc["en"] = "for internal use only";
        a.long_desc["de-DE"] = "Nur für internen Gebrauch";
        a.long_desc["fr-FR"] = "Seulement pour usage interne";
      
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
        fd.short_desc["en"] = "Returns the number of parent elements which contain the specified element as child element";
        fd.short_desc["de-DE"] = "Liefert die Anzahl der Elternelemente, in welchen das angegebene Element als Kindelement konsolidiert ist";
        fd.short_desc["fr-FR"] = "Donne le nombre des éléments consolidés qui contient l’élément parent défini.";
        fd.long_desc["en"] = "Returns the number of parent elements which contain the specified element as child element";
        fd.long_desc["de-DE"] = "Liefert die Anzahl der Elternelemente, in welchen das angegebene Element als Kindelement konsolidiert ist";
        fd.long_desc["fr-FR"] = "Donne le nombre des éléments consolidés qui contient l’élément parent défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Bse de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient les éléments.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément parent qui contient les éléments enfant.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the n th parent of the specified element";
        fd.short_desc["de-DE"] = "Liefert den Namen des n-ten Elternelements des angegebenen Elements";
        fd.short_desc["fr-FR"] = "Renvoie le nom de la partie parent énième de l’élément indiqué.";
        fd.long_desc["en"] = "Returns the name of the n th parent of the specified element";
        fd.long_desc["de-DE"] = "Liefert den Namen des n-ten Elternelements des angegebenen Elements";
        fd.long_desc["fr-FR"] = "Renvoie le nom de la partie parent énième de l’élément indiqué.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément dont l’élément parent doit être renvoyé.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Number of the parent element to retrieve.";
        a.long_desc["de-DE"] = "Nummer des Elternelements, das zurückgegeben werden soll";
        a.long_desc["fr-FR"] = "Numéro de position de l’élément qui doit être renvoyé.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the type of the specified element";
        fd.short_desc["de-DE"] = "Gibt den Typ des Elementes zurück";
        fd.short_desc["fr-FR"] = "Renvoie le nom de l’élément défini.";
        fd.long_desc["en"] = "Returns the type of the specified element";
        fd.long_desc["de-DE"] = "Gibt den Typ des Elementes zurück";
        fd.long_desc["fr-FR"] = "Renvoie le nom de l’élément défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element which type should be retrieved.";
        a.long_desc["de-DE"] = "Name des Elementes, dessen Typ ausgegeben werden soll";
        a.long_desc["fr-FR"] = "Nom de l’élément dont le type est indiqué.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the name of the specified sibling";
        fd.short_desc["de-DE"] = "Liefert den Namen des angegebenen Geschwisterelements";
        fd.short_desc["fr-FR"] = "Renvoie le nom de l’élément frère défini.";
        fd.long_desc["en"] = "Returns the name of the specified sibling";
        fd.long_desc["de-DE"] = "Liefert den Namen des angegebenen Geschwisterelements";
        fd.long_desc["fr-FR"] = "Renvoie le nom de l’élément frère défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient frère.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément dont l’élément défini enfant doit être indiqué.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Index number, which determines the sibling element";
        a.long_desc["de-DE"] = "Indexnummer, mit der das Schwesternelement bestimmt wird";
        a.long_desc["fr-FR"] = "Numéro de position avec lequel l’élément frère est défini.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Sets a value of a cube cell";
        fd.short_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle";
        fd.short_desc["fr-FR"] = "Établit la valeur d’un élément défini. Pour entrer des valeurs consolidées, le paramètre-Splash est paramétré sur \"VRAI\", dans le cas où il s’agit d’un élément de base, il sera paramétré sur \"Faux\" car la valeur ne peut être répartie dans des éléments de base.";
        fd.long_desc["en"] = "Sets a value of a cube cell";
        fd.long_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle";
        fd.long_desc["fr-FR"] = "Établit la valeur d’un élément défini. Pour entrer des valeurs consolidées, le paramètre-Splash est paramétré sur \"VRAI\", dans le cas où il s’agit d’un élément de base, il sera paramétré sur \"Faux\" car la valeur ne peut être répartie dans des éléments de base.";
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "The value to be written (string or double).";
        a.long_desc["de-DE"] = "Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = "Valeur devient (String ou Double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Splash";
        a.short_desc["de-DE"] = "Splash";
        a.short_desc["fr-FR"] = "Splash";
        a.long_desc["en"] = "TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = "WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = "\"VRAI\" s’il est écrit dans un élément consolidé. \"FAUX\" s’il est écrit dans un élément de base.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Nom du cube qui contient l’élément souhaité.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordonnée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Sets a value of a cube cell if the condition is true";
        fd.short_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.short_desc["fr-FR"] = "Écrit une valeur dans une cellule de cube, si la condition est vraie";
        fd.long_desc["en"] = "Sets a value of a cube cell if the condition is true";
        fd.long_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.long_desc["fr-FR"] = "Écrit une valeur dans une cellule de cube, si la condition est vraie";
        {
          ArgumentDocumentation a;
    
          a.name = "Condition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Condition";
        a.short_desc["de-DE"] = "Bedingung";
        a.short_desc["fr-FR"] = "Condition";
        a.long_desc["en"] = "The condition to be met";
        a.long_desc["de-DE"] = "Die Bedingung, die erfüllt sein muss";
        a.long_desc["fr-FR"] = "La condition pour l'action";
      
          fd.arg_pool["Condition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Value to be written(string or double)";
        a.long_desc["de-DE"] = "Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = "Valeur devient (String oder Double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Splash";
        a.short_desc["de-DE"] = "Splash";
        a.short_desc["fr-FR"] = "Splash";
        a.long_desc["en"] = "TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = "WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = "\"VRAI\" s’il est écrit dans un élément consolidé. \"FAUX\" s’il est écrit dans un élément de base.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinate";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans lequel les dimenisons sont créés dans le cube";
      
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
        fd.short_desc["en"] = "Sets a value of a cube cell if the condition is true";
        fd.short_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.short_desc["fr-FR"] = "Écrit une valeur dans une cellule de cube, si la condition est vraie.";
        fd.long_desc["en"] = "Sets a value of a cube cell if the condition is true";
        fd.long_desc["de-DE"] = "Schreibt einen Wert in eine Würfelzelle wenn die Bedingung WAHR ist";
        fd.long_desc["fr-FR"] = "Écrit une valeur dans une cellule de cube, si la condition est vraie.";
        {
          ArgumentDocumentation a;
    
          a.name = "Condition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Condition";
        a.short_desc["de-DE"] = "Bedingung";
        a.short_desc["fr-FR"] = "Condition";
        a.long_desc["en"] = "The condition to be met.";
        a.long_desc["de-DE"] = "Die Bedingung, die erfüllt sein muss";
        a.long_desc["fr-FR"] = "La condition à remplir.";
      
          fd.arg_pool["Condition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Value to be written(string or double)";
        a.long_desc["de-DE"] = "Der Wert der geschrieben werden soll (String oder Double)";
        a.long_desc["fr-FR"] = "La valeur à écrire (String ou double)";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Splash";
        a.short_desc["de-DE"] = "Splash";
        a.short_desc["fr-FR"] = "Splash";
        a.long_desc["en"] = "TRUE if you refer to a consolidated cell. FALSE if you refer to a base cell.";
        a.long_desc["de-DE"] = "WAHR, wenn in eine konsolidierte Zelle geschrieben wird. FALSCH, wenn in eine Basiszelle geschrieben wird";
        a.long_desc["fr-FR"] = "VRAI s'il est écrit dans une cellule consolidée. FAUX s'il est écrit dans une cellule de base.";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Name of the cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans l'ordre que dans le cube.";
      
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
        fd.short_desc["en"] = "Returns the value of the specified cell from the cube.";
        fd.short_desc["de-DE"] = "Liefert den Wert einer angegebenen Würfelzelle";
        fd.short_desc["fr-FR"] = "Renvoie la valeur d’une cellule de données à partir du cube si vous utilisez une fonction Excel matrice.";
        fd.long_desc["en"] = "Returns the value of the specified cell from the cube.";
        fd.long_desc["de-DE"] = "Liefert den Wert einer angegebenen Würfelzelle";
        fd.long_desc["fr-FR"] = "Renvoie la valeur d’une cellule de données à partir du cube si vous utilisez une fonction Excel matrice.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Nom du cube qui contient l’élément souhaité.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Plage de coordonnées dont les valeurs doivent être affichées. Les coordonnées sont précisées dans une matrice dans le même ordre que dans le cube mentionné.";
      
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
        fd.short_desc["en"] = "Returns the value of a cell from the cube.";
        fd.short_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel aus bzw. schreibt ihn dorthin zurück";
        fd.short_desc["fr-FR"] = "Lit la valeur de la cellule de données indiquée à partir du cube ou bien y récrit la valeur.";
        fd.long_desc["en"] = "Returns the value of the specified element from the cube";
        fd.long_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel aus bzw. schreibt ihn dorthin zurück";
        fd.long_desc["fr-FR"] = "Lit la valeur de la cellule de données indiquée à partir du cube ou bien y récrit la valeur";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Nom du cube qui contient l’élément souhaité.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Returns the value of a cell from the cube";
        fd.short_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel aus bzw. schreibt ihn dorthin zurück";
        fd.short_desc["fr-FR"] = "Lit la valeur de la cellule de données indiquée à partir du cube ou bien y récrit la valeur.";
        fd.long_desc["en"] = "Returns the value of a cell from the cube.";
        fd.long_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel aus bzw. schreibt ihn dorthin zurück";
        fd.long_desc["fr-FR"] = "Lit la valeur de la cellule de données indiquée à partir du cube ou bien y récrit la valeur.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Nom du cube qui contient l’élément souhaité.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Returns the value of a cell from the cube only if the function is on the active sheet.";
        fd.short_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel. Funktioniert nur, wenn sich die Funktion auf dem aktuellen Tabellenblatt befindet";
        fd.short_desc["fr-FR"] = "Renvoie la valeur d’un élément défini. Fonctionne seulement si la cellule se trouve sur la même feuille.";
        fd.long_desc["en"] = "Returns the value of a cell from the cube only if the function is on the active sheet.";
        fd.long_desc["de-DE"] = "Liest den Wert einer Datenzelle aus dem Würfel. Funktioniert nur, wenn sich die Funktion auf dem aktuellen Tabellenblatt befindet";
        fd.long_desc["fr-FR"] = "Renvoie la valeur d’un élément défini. Fonctionne seulement si la cellule se trouve sur la même feuille.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Returns the value of the specified string element.";
        fd.short_desc["de-DE"] = "Liest den Wert der beschriebenen Textzelle aus dem Würfel aus bzw. gibt diesen zurück";
        fd.short_desc["fr-FR"] = "Lit la valeur d’une cellule texte indiquée à partir du cube ou bien renvoie compte du cube.";
        fd.long_desc["en"] = "Returns the value of the specified string element.";
        fd.long_desc["de-DE"] = "Liest den Wert der beschriebenen Textzelle aus dem Würfel aus bzw. gibt diesen zurück";
        fd.long_desc["fr-FR"] = "Lit la valeur d’une cellule texte indiquée à partir du cube ou bien renvoie compte du cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Nom du cube qui contient l’élément souhaité.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans le quel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters";
        fd.short_desc["de-DE"] = "Gibt Daten entsprechend den Koordinaten zurück, ansonsten wird error zurückgegeben, wenn die Daten nicht abgerufen werden können. Es werden nur 255 Zeichen dargestellt";
        fd.short_desc["fr-FR"] = "Retourne les données aux coordonnées spécifiées ou d'erreur si les données n'ont pu être récupérés (version mise en cache). Il sera affichée seulement 255 caractères.";
        fd.long_desc["en"] = "Returns the data at the specified coordinates or error if the data could not be fetched (caching version). Breaks output every 255 characters.";
        fd.long_desc["de-DE"] = "Gibt Daten entsprechend den Koordinaten zurück, ansonsten wird error zurückgegeben, wenn die Daten nicht abgerufen werden können. Es werden nur 255 Zeichen dargestellt";
        fd.long_desc["fr-FR"] = "Retourne les données aux coordonnées spécifiées ou d'erreur si les données n'ont pu être récupérés (version mise en cache). Il sera affichée seulement 255 caractères.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans l'ordre que dans le cube.";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Value";
        a.long_desc["de-DE"] = "Wert";
        a.long_desc["fr-FR"] = "Valeur";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Splash";
        a.short_desc["de-DE"] = "Splash";
        a.short_desc["fr-FR"] = "Splash";
        a.long_desc["en"] = "Splash";
        a.long_desc["de-DE"] = "Splash";
        a.long_desc["fr-FR"] = "Splash";
      
          fd.arg_pool["Splash"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinate Array";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate Array";
        a.short_desc["de-DE"] = "Koordinatenarray";
        a.short_desc["fr-FR"] = "Array coordinée";
        a.long_desc["en"] = "Coordinate Array";
        a.long_desc["de-DE"] = "Koordinatenarray";
        a.long_desc["fr-FR"] = "Array coordinée";
      
          fd.arg_pool["Coordinate Array"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Value";
        a.long_desc["de-DE"] = "Wert";
        a.long_desc["fr-FR"] = "Valeur";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Splash";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Splash";
        a.short_desc["de-DE"] = "Splash";
        a.short_desc["fr-FR"] = "Splash";
        a.long_desc["en"] = "Splash";
        a.long_desc["de-DE"] = "Splash";
        a.long_desc["fr-FR"] = "Splash";
      
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
        fd.short_desc["en"] = "Returns the consolidation weight of a specified component of an element.";
        fd.short_desc["de-DE"] = "Gibt den Gewichtungsfaktor des beschriebenen Elements bei der Konsolidierung zurück";
        fd.short_desc["fr-FR"] = "Renvoie le facteur de pondération de l’élément indiqué lors de la consolidation.";
        fd.long_desc["en"] = "Returns the consolidation weight of a specified component of an element.";
        fd.long_desc["de-DE"] = "Gibt den Gewichtungsfaktor des beschriebenen Elements bei der Konsolidierung zurück";
        fd.long_desc["fr-FR"] = "Renvoie le facteur de pondération de l’élément indiqué lors de la consolidation.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à indiquer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Parent";
        a.short_desc["de-DE"] = "Elternelement";
        a.short_desc["fr-FR"] = "Parents";
        a.long_desc["en"] = "Name of the consolidation element (Parent Element).";
        a.long_desc["de-DE"] = "Name des konsolidierten Elements (Elternelement)";
        a.long_desc["fr-FR"] = "Nom de l’élément consolidé (élément parent)";
      
          fd.arg_pool["Parent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Child";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Name of the child element.";
        a.short_desc["de-DE"] = "Name des Kindelements";
        a.short_desc["fr-FR"] = "Nom de l'élément enfant.";
        a.long_desc["en"] = "Name of the child element.";
        a.long_desc["de-DE"] = "Name des Kindelements";
        a.long_desc["fr-FR"] = "Nom  de l’élément enfant";
      
          fd.arg_pool["Child"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the number of hierarchical levels which are below an element.";
        fd.short_desc["de-DE"] = "Gibt die Anzahl der Hierarchieebenen an, die unterhalb eines Elementes liegen";
        fd.short_desc["fr-FR"] = "Indique le nombre de degrés de hiérarchie à l’intérieur de la dimension qui existe encore après l’élément.";
        fd.long_desc["en"] = "Returns the number of hierarchical levels which are below an element.";
        fd.long_desc["de-DE"] = "Gibt die Anzahl der Hierarchieebenen an, die unterhalb eines Elementes liegen";
        fd.long_desc["fr-FR"] = "Indique le nombre de degrés de hiérarchie à l’intérieur de la dimension qui existe encore après l’élément.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element whose number of underlying levels should be returned.";
        a.long_desc["de-DE"] = "Name des Elementes, dessen darunterliegende Hierarchieebenenanzahl ausgegeben werden soll";
        a.long_desc["fr-FR"] = "Nom de l’élément dont le niveau, selon les degrés de hiérarchie à l’intérieur de la dimension, doit être indiqué selon l’élément à suivre.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the level of an element within a hierarchy (without parent-element: level 1, with one parent-level: level 2, etc.";
        fd.short_desc["de-DE"] = "Gibt die Stufe eines Elements innerhalb einer Hierarchie zurück (ohne Elternelement:Stufe 1, eine Elternebene darüber:Stufe 2, usw.";
        fd.short_desc["fr-FR"] = "Renvoie le degré de hiérarchie d’un élément à l’intérieur de la dimension.";
        fd.long_desc["en"] = "Returns the level of an element within a hierarchy (without parent-element: level 1, with one parent-level: level 2, etc.";
        fd.long_desc["de-DE"] = "Gibt die Stufe eines Elements innerhalb einer Hierarchie zurück (ohne Elternelement:Stufe 1, eine Elternebene darüber:Stufe 2, usw.";
        fd.long_desc["fr-FR"] = "Renvoie le degré de hiérarchie d’un élément à l’intérieur de la dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à donner.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element whose hierarchy-level should be returned.";
        a.long_desc["de-DE"] = "Name des Elementes, dessen Hierarchiestufe zurückgegeben werden soll";
        a.long_desc["fr-FR"] = "Nom de l’élément dont le degré de hiérarchie doit être renvoyé à l’intérieur de la dimension.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Returns the number of the parent-levels in a dimension.";
        fd.short_desc["de-DE"] = "Gibt die Anzahl der Elternebenen in einer Dimension zurück.";
        fd.short_desc["fr-FR"] = "Renvoie le niveau le plus élevé que possède un élément dans la hiérarchie de consolidation de la dimension indiquée.";
        fd.long_desc["en"] = "Returns the number of the parent-levels in a dimension.";
        fd.long_desc["de-DE"] = "Gibt die Anzahl der Elternebenen in einer Dimension zurück";
        fd.long_desc["fr-FR"] = "Renvoie le niveau le plus élevé que possède un élément dans la hiérarchie de consolidation de la dimension indiquée.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension dont le niveau de consolidation doit être indiqué.";
      
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
        fd.short_desc["en"] = "";
        fd.long_desc["en"] = "";
        {
          ArgumentDocumentation a;
    
          a.name = "Server";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server";
        a.short_desc["de-DE"] = "Server";
        a.short_desc["fr-FR"] = "Serveur";
        a.long_desc["en"] = "Server";
        a.long_desc["de-DE"] = "Server";
        a.long_desc["fr-FR"] = "Serveur";
      
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
        fd.short_desc["en"] = "Returns the list of all databases of a server.";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Datenbanken eines Servers";
        fd.short_desc["fr-FR"] = "Donne une liste avec toutes les bases de données du serveur spécifié.";
        fd.long_desc["en"] = "Returns the list of all databases of a server.";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Datenbanken eines Servers";
        fd.long_desc["fr-FR"] = "Donne une liste avec toutes les bases de données du serveur spécifié.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server";
        a.short_desc["de-DE"] = "Server";
        a.short_desc["fr-FR"] = "Serveur";
        a.long_desc["en"] = "Server";
        a.long_desc["de-DE"] = "Server";
        a.long_desc["fr-FR"] = "Serveur";
      
          fd.arg_pool["Server"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ListSystem";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "List system";
        a.short_desc["de-DE"] = "Zeige DB System";
        a.short_desc["fr-FR"] = "Afficher les bases de données système";
        a.long_desc["en"] = "List system databases too (TRUE/FALSE).";
        a.long_desc["de-DE"] = "Zeige auch Systemdatenbanken (WAHR/FALSCH)";
        a.long_desc["fr-FR"] = "Affiche aussi la base de données système (VRAI/FAUX)";
      
          fd.arg_pool["ListSystem"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ListUserInfo";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "List Userinfo";
        a.short_desc["de-DE"] = "Zeige auch Benutzerdatenbanken";
        a.short_desc["fr-FR"] = "Afficher les bases de données utilisateur";
        a.long_desc["en"] = "List userinfo databases too (TRUE/FALSE).";
        a.long_desc["de-DE"] = "Zeige auch Benutzerdatenbanken (WAHR/FALSCH)";
        a.long_desc["fr-FR"] = "Affichage également le base de données des utilisateurs(vrai/faux).";
      
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
        fd.short_desc["en"] = "Returns the list of all cubes of a database.";
        fd.short_desc["de-DE"] = "Listet alle Würfel einer Datenbank auf";
        fd.short_desc["fr-FR"] = "La fonction établit, dans une plage que vous aurez prédéfinie, une liste des cubes d’une base de données.";
        fd.long_desc["en"] = "Returns the list of all cubes of a server";
        fd.long_desc["de-DE"] = "Listet alle Würfel einer Datenbank auf";
        fd.long_desc["fr-FR"] = "La fonction établit, dans une plage que vous aurez prédéfinie, une liste des cubes d’une base de données.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "Optional: type of the cubes (0=normal, 1=system, 2=attribute, 3=userinfo, 4=gpu)";
        a.long_desc["de-DE"] = "Optional: Typ der Würfel (0=Normal, 1=System, 2=Attribut, 3=Benutzer, 4=GPU)";
        a.long_desc["fr-FR"] = "Optional: Type des cubes (0=normal, 1=system, 2=attribut, 3=userinfo, 4=gpu)";
      
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
        fd.short_desc["en"] = "Returns a list with all dimensions of a database.";
        fd.short_desc["de-DE"] = "Listet alle Dimensionen einer Datenbank auf";
        fd.short_desc["fr-FR"] = "La fonction établit, dans une plage que vous aurez prédéfinie, une liste des dimensions d’une base de données.";
        fd.long_desc["en"] = "Returns a list with all dimensions of a database";
        fd.long_desc["de-DE"] = "Listet alle Dimensionen einer Datenbank auf";
        fd.long_desc["fr-FR"] = "La fonction établit, dans une plage que vous aurez prédéfinie, une liste des dimensions d’une base de données.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "Optional: type of the dimensions (0=normal, 1=system, 2=attribute, 3=userinfo)";
        a.long_desc["de-DE"] = "Optional: Typ der Dimensionen (0=Normal, 1=System, 2=Attribut, 3=Benutzer)";
        a.long_desc["fr-FR"] = "Optional: Type des dimensions (0=normal, 1=system, 2=attribut, 3=userinfo, 4=gpu)";
      
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
        fd.short_desc["en"] = "Returns a list with all dimensions of a cube";
        fd.short_desc["de-DE"] = "Listet alle Dimensionen eines Würfels auf";
        fd.short_desc["fr-FR"] = "Donne une liste de toutes les dimensions d’un cube déterminé.";
        fd.long_desc["en"] = "Returns a list with all dimensions of a cube.";
        fd.long_desc["de-DE"] = "Listet alle Dimensionen eines Würfels auf";
        fd.long_desc["fr-FR"] = "Donne une liste de toutes les dimensions d’un cube déterminé.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Nom du cube dont les dimensions doivent être renvoyées.";
      
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
        fd.short_desc["en"] = "Returns a list of all cubes which contain a specified dimension.";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Würfeln, die die angegebene Dimension enthalten";
        fd.short_desc["fr-FR"] = "La fonction établit la liste de tous les cubes utilisés par des dimensions définies.";
        fd.long_desc["en"] = "Returns a list of all cubes which contain a specified dimension";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Würfeln, die die angegebene Dimensionenthalten";
        fd.long_desc["fr-FR"] = "La fonction établit la liste de tous les cubes utilisés par des dimensions définies.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension";
      
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
        fd.short_desc["en"] = "Returns the list with all elements of a specified dimension";
        fd.short_desc["de-DE"] = "der angegebenen Dimension enthalten sind";
        fd.short_desc["fr-FR"] = "Établit, dans une plage que vous aurez prédéfinie, la liste des éléments contenus dans une dimension.";
        fd.long_desc["en"] = "Returns the list with all elements of a specified dimension";
        fd.long_desc["de-DE"] = "der angegebenen Dimension enthalten sind";
        fd.long_desc["fr-FR"] = "Établit, dans une plage que vous aurez prédéfinie, la liste des éléments contenus dans une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient les éléments à agencer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Filter";
        a.short_desc["de-DE"] = "Filter";
        a.short_desc["fr-FR"] = "Filtre";
        a.long_desc["en"] = "Removes empty elements";
        a.long_desc["de-DE"] = "Entfernt leere Elemente.";
        a.long_desc["fr-FR"] = "Supprime les éléments vides.";
      
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
        fd.short_desc["en"] = "Returns the list of all elements for the specified dimension";
        fd.short_desc["de-DE"] = "Gibt eine Liste mit allen  Elementen der angegebenen  Dimension zurück";
        fd.short_desc["fr-FR"] = "RRetourne une liste avec toutes les éléments de la dimension specifiée.";
        fd.long_desc["en"] = "Returns the list of all elements for the specified dimension";
        fd.long_desc["de-DE"] = "Gibt eine Liste mit allen  Elementen der angegebenen  Dimension zurück";
        fd.long_desc["fr-FR"] = "Retourne une liste avec toutes les éléments de la dimension specifiée.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Filter";
        a.short_desc["de-DE"] = "Filter";
        a.short_desc["fr-FR"] = "Filtre";
        a.long_desc["en"] = "Removes empty elements";
        a.long_desc["de-DE"] = "Entfernt leere Elemente.";
        a.long_desc["fr-FR"] = "Supprime les éléments vides.";
      
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
        fd.short_desc["en"] = "Returns a list with all child elements of a consolidated element";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.short_desc["fr-FR"] = "Retourne une liste avec tous les éléments enfants d'un élément consolidé.";
        fd.long_desc["en"] = "Returns a list with all child elements of a consolidated element";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.long_desc["fr-FR"] = "Retourne une liste avec tous les éléments enfants d'un élément consolidé.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the consolidation element.";
        a.long_desc["de-DE"] = "Name des konsolidierten Elements";
        a.long_desc["fr-FR"] = "Name of the consolidation element";
      
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
        fd.short_desc["en"] = "Returns a list with all child elements of a consolidated element";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.short_desc["fr-FR"] = "Donne une liste de tous les éléments consolidés d’un élément défini.";
        fd.long_desc["en"] = "Returns a list with all child elements of a consolidated element";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Kindelementen eines konsolidierten Elements";
        fd.long_desc["fr-FR"] = "Donne une liste de tous les éléments consolidés d’un élément défini.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the Dimension which contains the specified element.";
        a.long_desc["de-DE"] = "Name der Dimension, die das bestimmte Element enthält";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément indiqué.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the consolidated element.";
        a.long_desc["de-DE"] = "Name des konsolidierten Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément consolidé.";
      
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
        fd.short_desc["en"] = "Returns a list with all parents of an element.";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Elternelementen eines Elements";
        fd.short_desc["fr-FR"] = "Retourne une liste de tous les parents d'un élément";
        fd.long_desc["en"] = "Returns a list with all parents of an element.";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Elternelementen eines Elements";
        fd.long_desc["fr-FR"] = "Retourne une liste de tous les parents d'un élément";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la Dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément";
      
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
        fd.short_desc["en"] = "Returns a list with all elements which are on the same hierarchy-level as the specified element";
        fd.short_desc["de-DE"] = "Name des Elementes";
        fd.short_desc["fr-FR"] = "Retourne une liste de tous les éléments qui sont sur le même niveau hiérarchique que l’élément spécifié";
        fd.long_desc["en"] = "Returns a list with all elements which are on the same hierarchy-level as the specified element.";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Elementen, die mit dem anzugebenden Element auf der gleichen Ebene liegen";
        fd.long_desc["fr-FR"] = "Retourne une liste de tous les éléments qui sont sur le même niveau hiérarchique que l’élément spécifié";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la Dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element.";
        a.long_desc["de-DE"] = "Name des Elementes";
        a.long_desc["fr-FR"] = "Nom de l’élément";
      
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
        fd.short_desc["en"] = "Deletes the specified element";
        fd.short_desc["de-DE"] = "Löscht das beschriebene Element";
        fd.short_desc["fr-FR"] = "Supprime l’élément indiqué.";
        fd.long_desc["en"] = "Deletes the specified element";
        fd.long_desc["de-DE"] = "Löscht das beschriebene Element";
        fd.long_desc["fr-FR"] = "Supprime l’élément indiqué.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension which contains the element that should be deleted.";
        a.long_desc["de-DE"] = "Name der Dimension, die das zu löschende Element enthält";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à supprimer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the element which shold be deleted.";
        a.long_desc["de-DE"] = "Name des Elementes, dass gelöscht werden soll.";
        a.long_desc["fr-FR"] = "Nom de l’élément qui doit être supprimé.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Deletes the specified element";
        fd.short_desc["de-DE"] = "Löscht das beschriebene Element";
        fd.short_desc["fr-FR"] = "Supprime l'élément spécifié.";
        fd.long_desc["en"] = "Deletes the specified element.";
        fd.long_desc["de-DE"] = "Löscht das beschriebene Element";
        fd.long_desc["fr-FR"] = "Supprime l'élément spécifié.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension which contains the element that should be deleted.";
        a.long_desc["de-DE"] = "Name der Dimension, die das zu löschende Element enthält";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l'élément qui doit être supprimé.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "ElementArray";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Array of element names which should be deleted.";
        a.long_desc["de-DE"] = "Ein Array mit Elementnamen, die gelöscht werden sollen";
        a.long_desc["fr-FR"] = "Array avec les noms d'éléments qui devraient être supprimés.";
      
          fd.arg_pool["ElementArray"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Entrez VRAI pour supprimer les messages d'erreur. Sinon, laissez en blanc.";
      
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
        fd.short_desc["en"] = "Adds the specified element to the database.";
        fd.short_desc["de-DE"] = "Fügt das beschriebene Element zur Datenbank hinzu";
        fd.short_desc["fr-FR"] = "Ajoute l’élément de dimension indiqué ou les structures à la base de données.";
        fd.long_desc["en"] = "Adds the specified element to the database.";
        fd.long_desc["de-DE"] = "Fügt das beschriebene Element zur Datenbank hinzu";
        fd.long_desc["fr-FR"] = "Ajoute l’élément de dimension indiqué ou les structures à la base de données.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension dans laquelle un élément doit être ajouté.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "Type of the new element (use \'N\' for numeric, \'C\' for consolidation or \'S\' for string element)";
        a.long_desc["de-DE"] = "Typ des einzufügenden Elements (anzugeben ist: \'N\' für numerisch, \'C\' für konsolidiert oder \'S\' für ein Text-Element)";
        a.long_desc["fr-FR"] = "Type de l’élément à ajouter (indiquez: \'N\' pour numérique, \'C\' pour consolidé ou \'S\' pour un élément string)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the new element.";
        a.long_desc["de-DE"] = "Name des Elementes, dass aktualisiert werden soll";
        a.long_desc["fr-FR"] = "Nom de l’élément qui doit être ajouté.";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Parent Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Parent Element";
        a.short_desc["de-DE"] = "Elternelement";
        a.short_desc["fr-FR"] = "Élément parent";
        a.long_desc["en"] = "Name of the parent element (use an empty string, if the new element should not be a child element).";
        a.long_desc["de-DE"] = "Name des Elternelements. Leer lassen wenn es ein Basiselement ist";
        a.long_desc["fr-FR"] = "Nom de l’élément consolidé ou d’un String vide si c’est un élément de base.";
      
          fd.arg_pool["Parent Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Weight";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Weight";
        a.short_desc["de-DE"] = "Konsolidierungsfaktor";
        a.short_desc["fr-FR"] = "Facteur de consolidation";
        a.long_desc["en"] = "Consolidation factor of the new element.";
        a.long_desc["de-DE"] = "Konsolidierungsfaktor des einzufügenden Elements";
        a.long_desc["fr-FR"] = "Facteur de consolidation de l’élément à ajouter.";
      
          fd.arg_pool["Weight"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Clear";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Clear";
        a.short_desc["de-DE"] = "Löschen";
        a.short_desc["fr-FR"] = "Effacer";
        a.long_desc["en"] = "TRUE deletes the existing elements in the Dimensionbefore the import, FALSE adds the new element without clearing any elements before.";
        a.long_desc["de-DE"] = "WAHR entfernt vor dem Import alle vorhandenen Elemente der Dimension, FALSCH  fügt das Element hinzu ohne irgendwelche Elemente vorher zu löschen";
        a.long_desc["fr-FR"] = "Supprime avant l’import tous les éléments présents de la dimension si la requête (Vrai/Faux) est sur VRAI, autrement un élément est ajouté sans que la dimension soit auparavant supprimée.";
      
          fd.arg_pool["Clear"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Updates an existing element";
        fd.short_desc["de-DE"] = "Aktualisiert ein existierendes Element";
        fd.short_desc["fr-FR"] = "Fonction pour actualiser d'un élément existant";
        fd.long_desc["en"] = "Updates an existing element";
        fd.long_desc["de-DE"] = "Aktualisiert ein existierendes Element";
        fd.long_desc["fr-FR"] = "Fonction pour actualiser d'un élément existant";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Name of the new element.";
        a.long_desc["de-DE"] = "Name des Elementes, dass aktualisiert werden soll";
        a.long_desc["fr-FR"] = "Nom de l'élément qui doit être actualisé";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "Type of the new element (use \'N\' for numeric, \'C\' for consolidation or \'S\' for string element)";
        a.long_desc["de-DE"] = "Typ des einzufügenden Elements (anzugeben ist: \'N\' für numerisch, \'C\' für konsolidiert oder \'S\' für ein Text-Element)";
        a.long_desc["fr-FR"] = "Type de l'élément (anzugeben ist: \'N\' für numerisch, \'C\' für konsolidiert oder \'S\' für ein String element)";
      
          fd.arg_pool["Type"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Children";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "C-Elements";
        a.short_desc["de-DE"] = "C-Elemente";
        a.short_desc["fr-FR"] = "Éléments consolidés.";
        a.long_desc["en"] = "Array with consolidated elements. Leave blank if you just want to change the type of an element.";
        a.long_desc["de-DE"] = "Ein Array bestehend aus konsolidierten Elementen. Einfach leer lassen um nur den Typ des Elementes zu ändern";
        a.long_desc["fr-FR"] = "Une matrice des  éléments consolidés. Ce paramètre sera laissé vide pour changer seulement le type.";
      
          fd.arg_pool["Children"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Append";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Append";
        a.short_desc["de-DE"] = "Hinzufügen";
        a.short_desc["fr-FR"] = "Ajouter";
        a.long_desc["en"] = "Append the children";
        a.long_desc["de-DE"] = "Kinder hinzufügen";
        a.long_desc["fr-FR"] = "Ajouter les enfants";
      
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
        fd.short_desc["en"] = "Renames the specified element";
        fd.short_desc["de-DE"] = "Benennt das angegebene Element um";
        fd.short_desc["fr-FR"] = "Renomme l’élément indiqué.";
        fd.long_desc["en"] = "Renames the specified element";
        fd.long_desc["de-DE"] = "Benennt das angegebene Element um";
        fd.long_desc["fr-FR"] = "Renomme l’élément indiqué.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension dans laquelle l’élément défini doit être renommé.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Old Name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Old Name";
        a.short_desc["de-DE"] = "Alter Name";
        a.short_desc["fr-FR"] = "L'ancien nom";
        a.long_desc["en"] = "Name of the element, whose name should be changed.";
        a.long_desc["de-DE"] = "Name des Elementes, dessen Name geändert werden soll";
        a.long_desc["fr-FR"] = "Ancien nom";
      
          fd.arg_pool["Old Name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "New Name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "New Name";
        a.short_desc["de-DE"] = "Neuer Name";
        a.short_desc["fr-FR"] = "Nouveau nom";
        a.long_desc["en"] = "New Name";
        a.long_desc["de-DE"] = "Neuer Name";
        a.long_desc["fr-FR"] = "Nouveau nom";
      
          fd.arg_pool["New Name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "Writes the records, which returns error during the import loop, in an error file.";
        fd.short_desc["de-DE"] = "Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.short_desc["fr-FR"] = "Écrit les records qui renvoie une erreur lors de la boucle d'importation, dans un fichier d'erreur.";
        fd.long_desc["en"] = "Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["de-DE"] = "Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.long_desc["fr-FR"] = "Écrit les enregistrements, qui renvoie une erreur lors de la boucle de l'importation, dans un fichier d'erreur.";
        {
          ArgumentDocumentation a;
    
          a.name = "Error";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Error";
        a.short_desc["de-DE"] = "Fehler";
        a.short_desc["fr-FR"] = "Erreur";
        a.long_desc["en"] = "Cell that contains the error, so the cell with the Palo.Setdata function.";
        a.long_desc["de-DE"] = "Die Zelle, in der der Fehler entsteht, also die Zelle mit der Palo.Setdata-Funktion";
        a.long_desc["fr-FR"] = "La cellule dans laquelle il devient l'erreur, à savoir la cellule avec la fonction Palo.Setdata.";
      
          fd.arg_pool["Error"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Path";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Path";
        a.short_desc["de-DE"] = "Pfad";
        a.short_desc["fr-FR"] = "Chemin";
        a.long_desc["en"] = "Path and name of the errorfile";
        a.long_desc["de-DE"] = "Pfadangabe und Name der Fehlerdatei";
        a.long_desc["fr-FR"] = "Chemin et nom de fichier d'erreurs.";
      
          fd.arg_pool["Path"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Erroneous value";
        a.long_desc["de-DE"] = "Fehlerhafter Wert.";
        a.long_desc["fr-FR"] = "Valeur incorrecte";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans l'ordre que dans le cube.";
      
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
        fd.short_desc["en"] = "Writes the records, which returns error during the import loop, in an error file.";
        fd.short_desc["de-DE"] = "Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.short_desc["fr-FR"] = "Écrit les enregistrements d’un fichier import qui ne correspondent pas aux spécifications de l’import dans un fichier erreur.";
        fd.long_desc["en"] = "Writes the records, which returns error during the import loop, in an error file.";
        fd.long_desc["de-DE"] = "Schreibt die Datensätze einer Importdatei, die während des Imports Fehler auslösen, in eine Fehlerdatei";
        fd.long_desc["fr-FR"] = "Écrit les enregistrements d’un fichier import qui ne correspondent pas aux spécifications de l’import dans un fichier erreur.";
        {
          ArgumentDocumentation a;
    
          a.name = "Error";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Error";
        a.short_desc["de-DE"] = "Fehler";
        a.short_desc["fr-FR"] = "Erreur";
        a.long_desc["en"] = "Cell that contains the error, so the cell with the Palo.Setdata function";
        a.long_desc["de-DE"] = "Die Zelle, in der der Fehler entsteht, also die Zelle mit der Palo.Setdata-Funktion";
        a.long_desc["fr-FR"] = "La cellule contenant l’erreur, soit la cellule avec la fonction-\"Palo.Setdata\"";
      
          fd.arg_pool["Error"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Path";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Path";
        a.short_desc["de-DE"] = "Pfad";
        a.short_desc["fr-FR"] = "Chemin";
        a.long_desc["en"] = "Path and name of the errorfile.";
        a.long_desc["de-DE"] = "Pfad und Name der Fehlerdatei.";
        a.long_desc["fr-FR"] = "Le fichier avec le chemin dans lequel les erreurs sont enregistrés.";
      
          fd.arg_pool["Path"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Value";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Value";
        a.short_desc["de-DE"] = "Wert";
        a.short_desc["fr-FR"] = "Valeur";
        a.long_desc["en"] = "Erroneous value";
        a.long_desc["de-DE"] = "Fehlerhafter Wert.";
        a.long_desc["fr-FR"] = "Valeur erronée.";
      
          fd.arg_pool["Value"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Nom du cube.";
      
          fd.arg_pool["Cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Coordinates";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Coordinate";
        a.short_desc["de-DE"] = "Koordinate";
        a.short_desc["fr-FR"] = "Coordinée";
        a.long_desc["en"] = "The coordinates are specified in the order as in the cube.";
        a.long_desc["de-DE"] = "Koordinaten werden in der gleichen Reihenfolge angegeben, in der die Dimensionen im Würfel angelegt sind";
        a.long_desc["fr-FR"] = "Les coordonnées sont précisées dans le même ordre dans lequel les dimensions ont été créées dans le cube.";
      
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
        fd.short_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension.";
        fd.long_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données.";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Global";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Global";
        a.short_desc["de-DE"] = "Global";
        a.short_desc["fr-FR"] = "Global";
        a.long_desc["en"] = "TRUE shows a global subset. FALSE executes a local subset.";
        a.long_desc["de-DE"] = "WAHR zeigt ein globales Subset an. FALSCH zeigt ein lokales Subset an";
        a.long_desc["fr-FR"] = "global";
      
          fd.arg_pool["Global"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Subsetname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Subsetname";
        a.short_desc["de-DE"] = "Subsetname";
        a.short_desc["fr-FR"] = "Le nom de sous-ensemble";
        a.long_desc["en"] = "Name of the Subset.";
        a.long_desc["de-DE"] = "Name des Subset";
        a.long_desc["fr-FR"] = "Nom du sous-ensemble.";
      
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
        fd.short_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = "Retourne un sous-ensemble d'éléments.";
        fd.long_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = "Retourne un sous-ensemble d'éléments.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Global";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Global";
        a.short_desc["de-DE"] = "Global";
        a.short_desc["fr-FR"] = "Global";
        a.long_desc["en"] = "TRUE shows a global subset. FALSE executes a local subset.";
        a.long_desc["de-DE"] = "WAHR zeigt ein globales Subset an. FALSCH zeigt ein lokales Subset an";
        a.long_desc["fr-FR"] = "Avec VRAI est créé un sous-ensemble global, avec FAUX est créé un sous-ensemble local.";
      
          fd.arg_pool["Global"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Subsetname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Subsetname";
        a.short_desc["de-DE"] = "Subsetname";
        a.short_desc["fr-FR"] = "Le nom de sous-ensemble";
        a.long_desc["en"] = "Name of the Subset.";
        a.long_desc["de-DE"] = "Name des Subset";
        a.long_desc["fr-FR"] = "Name of the Subset";
      
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
        fd.short_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.short_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.short_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension.";
        fd.long_desc["en"] = "Returns a subset of Dimensionelements.";
        fd.long_desc["de-DE"] = "Gibt eine Teilmenge von Dimensionselementen zurück";
        fd.long_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient les éléments à indiquer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Indent";
        a.short_desc["de-DE"] = "Einrückung";
        a.short_desc["fr-FR"] = "Indentation";
        a.long_desc["en"] = "Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = "Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = "Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Alias";
        a.short_desc["de-DE"] = "Alias";
        a.short_desc["fr-FR"] = "Alias";
        a.long_desc["en"] = "Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = "Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = "Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Filter";
        a.short_desc["de-DE"] = "Filter";
        a.short_desc["fr-FR"] = "Filtre";
        a.long_desc["en"] = "Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = "Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = "Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou SORT";
      
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
        fd.short_desc["en"] = "Returns a subset of Dimensionelements if called from active sheet";
        fd.short_desc["de-DE"] = "Gibt dann eine Teilmenge von Dimensionselementen zurück, wenn die Fkt. vom aktiven Blatt aufgerufen wird";
        fd.short_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension si est appelée depuis une feuille active.";
        fd.long_desc["en"] = "Returns a subset of Dimensionelements if called from active sheet";
        fd.long_desc["de-DE"] = "Gibt dann eine Teilmenge von Dimensionselementen zurück, wenn die Fkt. vom aktiven Blatt aufgerufen wird";
        fd.long_desc["fr-FR"] = "Renvoie un sous-ensemble d’éléments de dimension si est appelée depuis une feuille active.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient les éléments À indiquer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Indent";
        a.short_desc["de-DE"] = "Einrückung";
        a.short_desc["fr-FR"] = "Indentation";
        a.long_desc["en"] = "Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = "Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = "Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Alias";
        a.short_desc["de-DE"] = "Alias";
        a.short_desc["fr-FR"] = "Alias";
        a.long_desc["en"] = "Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = "Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = "Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Filter";
        a.short_desc["de-DE"] = "Filter";
        a.short_desc["fr-FR"] = "Filtre";
        a.long_desc["en"] = "Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = "Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = "Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou SORT.";
      
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
        fd.short_desc["en"] = "Returns the length of a subset of Dimensionelements";
        fd.short_desc["de-DE"] = "Gibt die Elementanzahl des Subsets zurück";
        fd.short_desc["fr-FR"] = "Renvoie la longueur d’un extrait d’ensemble d’un élément de dimension.";
        fd.long_desc["en"] = "Returns the length of a subset of Dimensionelements";
        fd.long_desc["de-DE"] = "Gibt die Elementanzahl des Subsets zurück";
        fd.long_desc["fr-FR"] = "Renvoie la longueur d’un extrait d’ensemble d’un élément de dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension qui contient l’élément à indiquer.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Indent";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Indent";
        a.short_desc["de-DE"] = "Einrückung";
        a.short_desc["fr-FR"] = "Indentation";
        a.long_desc["en"] = "Entry of \"1\" or \"2\" or \"3\" controls the kind of indent. If empty the view is flat";
        a.long_desc["de-DE"] = "Mit der Eingabe von \"1\" oder \"2\" oder \"3\" wird die Art der eingerückten Darstellung kontrolliert(indent/level/depth). Leer erzeugt eine Ansicht ohne Einrückung";
        a.long_desc["fr-FR"] = "Avec l’indentation de \"1\" ou \"2\" ou \"3\" est contrôlée la forme de la vue indentée (indent/level/depth). Si vide, correspond à une vue plate.";
      
          fd.arg_pool["Indent"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Alias";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Alias";
        a.short_desc["de-DE"] = "Alias";
        a.short_desc["fr-FR"] = "Alias";
        a.long_desc["en"] = "Alternative name for an element that defined as an attribute";
        a.long_desc["de-DE"] = "Alternativname für ein Element, welches als Attribut definiert worden ist. Es können maximal 2 Aliase angeben werden";
        a.long_desc["fr-FR"] = "Nom alternatif pour un élément lequel a été défini en tant qu’attribut. Maximum 2 Alias peuvent être indiqués.";
      
          fd.arg_pool["Alias"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Filter";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Filter";
        a.short_desc["de-DE"] = "Filter";
        a.short_desc["fr-FR"] = "Filtre";
        a.long_desc["en"] = "Result of DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER or SORT.";
        a.long_desc["de-DE"] = "Ergebnis von DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER oder SORT";
        a.long_desc["fr-FR"] = "Résultat de DFILTER, AFILTER, PICKLIST, HFILTER, TFILTER ou. SORT.";
      
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
        fd.short_desc["en"] = "Adds elements to the subset which can not deleted by no way. Or it can be defined elements as a pre-selection.";
        fd.short_desc["de-DE"] = "Kann Elemente zum SubSet hinzufügen, die dann auf keinen Fall wieder entfernt werden. Oder es können Elemente als eine Vorauswahl definiert werden";
        fd.short_desc["fr-FR"] = "Peut ajouter des éléments à un sous-ensemble qui ne peuvent en aucun cas être à nouveau supprimés. En outre, il est possible de définir par ces derniers une multitude d’éléments qui feront office de filtre.";
        fd.long_desc["en"] = "Adds elements to the subset which can not deleted by no way. Or it can be defined elements as a pre-selection.";
        fd.long_desc["de-DE"] = "Kann Elemente zum SubSet hinzufügen, die dann auf keinen Fall wieder entfernt werden. Oder es können Elemente als eine Vorauswahl definiert werden";
        fd.long_desc["fr-FR"] = "Peut ajouter des éléments à un sous-ensemble qui ne peuvent en aucun cas être à nouveau supprimés. En outre, il est possible de définir par ces derniers une multitude d’éléments qui feront office de filtre.";
        {
          ArgumentDocumentation a;
    
          a.name = "definition";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Definition";
        a.short_desc["de-DE"] = "Definition";
        a.short_desc["fr-FR"] = "Définition";
        a.long_desc["en"] = "Creation of elements, which will be added to the subset";
        a.long_desc["de-DE"] = "Definition der Elemente, die zum Subset hinzugefügt werden";
        a.long_desc["fr-FR"] = "Définition des éléments qui sont ajoutés au sous-ensemble.";
      
          fd.arg_pool["definition"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "0/empty = Elements will be added at the beginning of the subset, 1 = Elements will be added at the end of the subset, 2 = Elements will be merged into the subset, 3 = Picklist-elements are the exclusive pre-selection for the subset";
        a.long_desc["de-DE"] = "0/leer = Elemente werden am Anfang des Subsets hinzugefügt, 1 = Elemente werden am Ende Subsets hinzugefügt, 2 = Elemente werden in das Subset sortiert eingefügt, 3 = Elemente sind die exclusive Vorauswahl für das Subset";
        a.long_desc["fr-FR"] = "Formes comme éléments seront ajoutés au sous-ensemble. 0/vide = éléments seront mis au début du sous-ensemble, 1 = éléments seront mis à la fin du sous-ensemble, 2 = éléments seront ajoutés en";
      
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
        fd.short_desc["en"] = "Elements which match the specified string model will be shown, the rest will be removed. More than on filter criteria can be specified in an array.";
        fd.short_desc["de-DE"] = "Elemente, deren Namen bestimmten Mustern entsprechen, werden beibehalten, der Rest wird aus der Anzeige entfernt. Mehrere Filterkriterien können in einem Array angegeben werden";
        fd.short_desc["fr-FR"] = "Éléments dont les noms correspondent à des modèles définis, sont conservés. Le reste est supprimé de l’affichage. Plusieurs critères de filtre sont indiqués dans la matrice.";
        fd.long_desc["en"] = "Elements which match the specified string model will be shown, the rest will be removed. More than on filter criteria can be specified in an array.";
        fd.long_desc["de-DE"] = "Elemente, deren Namen bestimmten Mustern entsprechen, werden beibehalten, der Rest wird aus der Anzeige entfernt. Mehrere Filterkriterien können in einem Array angegeben werden";
        fd.long_desc["fr-FR"] = "Éléments dont les noms correspondent à des modèles définis, sont conservés. Le reste est supprimé de l’affichage. Plusieurs critères de filtre sont indiqués dans la matrice.";
        {
          ArgumentDocumentation a;
    
          a.name = "regex";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Regex";
        a.short_desc["de-DE"] = "Regex";
        a.short_desc["fr-FR"] = "Regex";
        a.long_desc["en"] = "DOS filter criteria. \"D*\" for example removes all elements which do not beginn with \"D\"";
        a.long_desc["de-DE"] = "DOS Filterkriterien. \"D*\" bewirkt z.B. dass alle Elemente entfernt werden die nicht mit \"D\" beginnen.";
        a.long_desc["fr-FR"] = "DOS critères de tri. Produit le fait que tous les éléments qui ne commencent pas avec \"D\" ou un \"k\", seront supprimés. Le point d’interrogation  (\?) produit l’inverse du signe de valeur générale (*).";
      
          fd.arg_pool["regex"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "extended";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Extended";
        a.short_desc["de-DE"] = "Erweitert";
        a.short_desc["fr-FR"] = "Avancé";
        a.long_desc["en"] = "Extended filter criteria. \"X$\" for example removes all elements which do not end with an \"X\"";
        a.long_desc["de-DE"] = "Erweiterte Filterkriterien. \"X$\" bewirkt z.B. dass alle Elemente entfernt werden, die nicht mit \"X\" enden";
        a.long_desc["fr-FR"] = "Extended produit le fait que tous les éléments qui ne se terminent pas par \"X\" ou ne contiennent pas  \"s\" ou un \"d\", seront affichés.";
      
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
        fd.short_desc["en"] = "Sort the elements of a subset in a given order. For example order of definition or hierarchical order.";
        fd.short_desc["de-DE"] = "Sortiert die Elemente des SubSets in einer bestimmten Reihenfolge, z.B. in der Definitionsreihenfolge oder der hierarchischen Reihenfolge";
        fd.short_desc["fr-FR"] = "Définit l'affichage des éléments du sous-ensemble, par exemple en ordre de définition ou en ordre hiérarchique.";
        fd.long_desc["en"] = "Sort the elements of a subset in a given order. For example order of definition or hierarchical order";
        fd.long_desc["de-DE"] = "Sortiert die Elemente des SubSets in einer bestimmten Reihenfolge, z.B. in der Definitionsreihenfolge oder der hierarchischen Reihenfolge";
        fd.long_desc["fr-FR"] = "Définit l'affichage des éléments du sous-ensemble, par exemple en ordre de définition ou en ordre hiérarchique.";
        {
          ArgumentDocumentation a;
    
          a.name = "whole";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Whole";
        a.short_desc["de-DE"] = "Gesamtheit";
        a.short_desc["fr-FR"] = "Entier";
        a.long_desc["en"] = "\"0\"/empty = Definition order - default \"1\" = Shows hierarchy with child elements of elements which were removed from the subset. \"2\" = Cuts the view at this position";
        a.long_desc["de-DE"] = "\"0\"/leer = Definitionsreihenfolge  \"1\" = Hierarchieansicht mit Kindern von Elementen, die aus dem Subset entfernt wurden. \"2\" = Schneidet die Ansicht an diesen Stellen ab";
        a.long_desc["fr-FR"] = "\"0\"/empty Montre les éléments en l'ordre de définition. \"1\" montre les enfants d’éléments qui ont été supprimés du sous-ensemble. \"2\" coupe la vue à ces endroits.";
      
          fd.arg_pool["whole"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "criteria";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Criteria";
        a.short_desc["de-DE"] = "Kriterium";
        a.short_desc["fr-FR"] = "Critères";
        a.long_desc["en"] = "Grade for 0/empty = Definition, 1 = Data, 2 = Text, 3 = Alias";
        a.long_desc["de-DE"] = "Sortiere nach 0/leer = Definition, 1 = Daten, 2 = Text, 3 = Alias";
        a.long_desc["fr-FR"] = "Trie selon 0/vide = Définition, 1 = Données, 2 = Texte, 3 = Alias";
      
          fd.arg_pool["criteria"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Attribute";
        a.short_desc["de-DE"] = "Attribut";
        a.short_desc["fr-FR"] = "Attribut";
        a.long_desc["en"] = "Sorts by attributes. This filter should not be used with \"Criteria\"";
        a.long_desc["de-DE"] = "Sortiert nach den Attributen. Dieser Filter sollte nicht mit \"Criteria\" zusammen verwendet werden.";
        a.long_desc["fr-FR"] = "Trie selon les termes qui ont été définis par des attributs. Ce filtre ne devrait pas être utilisé avec \"Criteria\".";
      
          fd.arg_pool["attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "type_limitation";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type limitation";
        a.short_desc["de-DE"] = "Typbegrenzung";
        a.short_desc["fr-FR"] = "Limitation de type";
        a.long_desc["en"] = "This function just works with Criteria and Whole together. 0/empty = no action, 1 = sorting of basic elements only, 2 = sort only consolidated elements";
        a.long_desc["de-DE"] = "Funktioniert nur zusammen mit Criteria und Whole. 0/leer = keine Wirkung, 1 = sortiert nur die Basiselemente, 2 = sortiert nur die Konsolidierungen";
        a.long_desc["fr-FR"] = "Fonctionne seulement avec Critère et Affichage. 0/vide = aucun effet, 1 = trie seulement les éléments de base, 2 = trie les consolidations.";
      
          fd.arg_pool["type_limitation"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Level element";
        a.short_desc["de-DE"] = "Elementebene";
        a.short_desc["fr-FR"] = "Si n’est pas vide, il ne sera trié qu’au niveau de cet élément.";
        a.long_desc["en"] = "This function works with Criteria and Whole only. If not empty, it will sort on the given level";
        a.long_desc["de-DE"] = "Funktioniert nur zusammen mit Criteria und Whole. Falls nicht leer, sortiere nur auf der angegebenen Ebene";
        a.long_desc["fr-FR"] = "Fonctionne uniquement avec Critère et Affichage. Si n’est pas vide, trie seulement sur les niveaux indiqués.";
      
          fd.arg_pool["level"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "reverse";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Reverse";
        a.short_desc["de-DE"] = "Umgekehrt";
        a.short_desc["fr-FR"] = "Inverse le tri. 0/vide = aucun effet, 1= éléments consolidés en-dessous, 2= total, 3= 1 et 2 combinés";
        a.long_desc["en"] = "Reverse the sorting. 0/empty = no action, 1= Consolidations below, 2 = total, 3= 1 and 2 combined";
        a.long_desc["de-DE"] = "Kehrt die Sortierung um. 0/leer = keine Wirkung, 1= Konsolidierte Elemente unterhalb, 2= total, 3= 1 und 2 kombiniert";
        a.long_desc["fr-FR"] = "0/vide = aucun effet\n1 = représentation hiérarchique avec les parents en-dessous des enfants et sur chaque niveau, tri selon Criteria\n2 = inversion complète du tri selon Criteria\n3 = représentation hiérarchique et inversement du tri selon Criteria sur chaque niveau.";
      
          fd.arg_pool["reverse"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "show_duplicates";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Show duplicates";
        a.short_desc["de-DE"] = "Zeige Duplikate";
        a.short_desc["fr-FR"] = "Afficher les doublons.";
        a.long_desc["en"] = "Display of duplicate values, 0/empty = hide duplicates, 1 = show duplicates";
        a.long_desc["de-DE"] = "Duplikatsanzeige: 0/leer = Zeige keine Duplikate an, 1 = Zeige Duplikate an";
        a.long_desc["fr-FR"] = "Affichage des doublons, 0/vide n’affiche pas de duplicata, 1 autorise les duplicata.";
      
          fd.arg_pool["show_duplicates"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "limit_count";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "limit count";
        a.short_desc["de-DE"] = "Begrenze Anzahl";
        a.short_desc["fr-FR"] = "Limite le nombre d'éléments retournés.";
        a.long_desc["en"] = "limit the count of returned elements";
        a.long_desc["de-DE"] = "Begrenze die Anzahl zurückgegebener Elemente";
        a.long_desc["fr-FR"] = "Limite le nombre d'éléments retournés.";
      
          fd.arg_pool["limit_count"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "limit_start";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "start limiting at";
        a.short_desc["de-DE"] = "Beginne Begrenzung bei";
        a.short_desc["fr-FR"] = "Commence l'addition des éléments retournés à";
        a.long_desc["en"] = "start the limitation the count of returned elements at";
        a.long_desc["de-DE"] = "Beginne die Begrenzung der Anzahl zurückgegebener Elemente bei";
        a.long_desc["fr-FR"] = "Commence l'addition des éléments retournés à";
      
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
        fd.short_desc["en"] = "The attribute filter removes elements which do not match with the defined attribut rows";
        fd.short_desc["de-DE"] = "Der Attribut-Filter entfernt Elemente, auf die definierte Attributzeilen nicht zutreffen";
        fd.short_desc["fr-FR"] = "Le filtre attribut supprime des éléments pour lesquels les lignes attribut définies ne correspondent pas.";
        fd.long_desc["en"] = "The attribute filter removes elements which do not match with the defined attribut rows";
        fd.long_desc["de-DE"] = "Der Attribut-Filter entfernt Elemente, auf die definierte Attributzeilen nicht zutreffen";
        fd.long_desc["fr-FR"] = "Le filtre attribut supprime des éléments pour lesquels les lignes attribut définies ne correspondent pas.";
        {
          ArgumentDocumentation a;
    
          a.name = "advanced filter matrix";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Advanced filter matrix";
        a.short_desc["de-DE"] = "Filtermatrix";
        a.short_desc["fr-FR"] = "Matrice avancé de filtre";
        a.long_desc["en"] = "Array contains the definition for the field-filter. Supported operators for numeric criteria are: \" <, >, = \"";
        a.long_desc["de-DE"] = "Array enthält die Definition für die Feld-Filter. Unterstützte Operatoren für nummerische Kriterien sind: \" <, >, = \"";
        a.long_desc["fr-FR"] = "Matrice Filtre Avancée contient la définition pour les filtres-champs. Opérateurs supportés pour des critères numériques sont: &lt;, &gt;, \'=";
      
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
        fd.short_desc["en"] = "Defines hierarchically a subset with criteria relative to 1. ELEMENT or 2. REVOLVE_ELEMENT.  It should be specified only cover 1 or 2.";
        fd.short_desc["de-DE"] = "Definiert hierarchisch ein Subset über Kriterien in Bezug auf 1. ELEMENT  oder 2. REVOLVE_ELEMENT. Es sollte nur Bezug 1 oder 2 angegeben werden";
        fd.short_desc["fr-FR"] = "1. Filtre des éléments à partir d’un sous-ensemble en définissant des critères de structure. 2. Répétition d’un sous ensemble avec des critères de structure légèrement modifiés. Point 1 et Point 2 ne peuvent pas être combinés.";
        fd.long_desc["en"] = "Defines hierarchically a subset with criteria relative to 1. ELEMENT or 2. REVOLVE_ELEMENT.  It should be specified only cover 1 or 2.";
        fd.long_desc["de-DE"] = "Definiert hierarchisch ein Subset über Kriterien in Bezug auf 1. ELEMENT  oder 2. REVOLVE_ELEMENT. Es sollte nur Bezug 1 oder 2 angegeben werden";
        fd.long_desc["fr-FR"] = "1. Filtre des éléments à partir d’un sous-ensemble en définissant des critères de structure. 2. Répétition d’un sous ensemble avec des critères de structure légèrement modifiés. Point 1 et Point 2 ne peuvent pas être combinés";
        {
          ArgumentDocumentation a;
    
          a.name = "element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Selection of elements, which are above or below of ELEMENT in the hierarchy. Empty = elements below ELEMENT, TRUE = elements above ELEMENT will be displayed.";
        a.long_desc["de-DE"] = "Auswahl von Elementen, die in der Hierarchie über oder unter ELEMENT liegen. Leer = Darunterliegende,  WAHR = Darüberliegende Elemente werden genommen";
        a.long_desc["fr-FR"] = "Permet la sélection d'éléments qui se situent dans la hiérarchie de dimension au-dessus ou au-dessous de « l'élément ».";
      
          fd.arg_pool["element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "above";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Above";
        a.short_desc["de-DE"] = "Oberhalb";
        a.short_desc["fr-FR"] = "Cet argument peut seulement être utilisé avec 'Element'. Avec VRAI, les éléments sont sélectionnés\nqui sont au-dessus de 'Element' dans la hiérarchie.\nAvec FAUX (ou vide) les éléments sont sélectionnés qui\nsont en-dessous hiérarchiquement.";
        a.long_desc["en"] = "This criteria works only with element. TRUE = All elements in higher-level hierarchy will be handled. FALSE/empty = All elements in less-level hierarchy will be handled.";
        a.long_desc["de-DE"] = "Kann nur zusammen mit Element verwendet werden. WAHR = Alle Elemente, die in der Hierarchie oberhalb stehen, FALSCH/leer = Alle Elemente, die in der Hierarchie unterhalb stehen, werden genommen";
        a.long_desc["fr-FR"] = "Ne peut être utilisé uniquement qu’avec Élément. VRAI = tous les éléments au-dessus de «l'élément» sont pris. FAUX/vide = tous les éléments au-dessous de «l'élément» sont pris.";
      
          fd.arg_pool["above"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "exclusive";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Exclusive";
        a.short_desc["de-DE"] = "Exclusiv";
        a.short_desc["fr-FR"] = "Cet argument peut seulement être utilisé avec ELEMENT.\nVRAI = n’affiche pas l’élément sélectionné avec ELEMENT. Vide ou FAUX = affiche cet élément.";
        a.long_desc["en"] = "TRUE = Element will not be shown. FALSE or empty = Element will be shown.";
        a.long_desc["de-DE"] = "WAHR = Das Element wird nicht angezeigt. FALSE oder Leer = Das Element selbst wird mit angezeigt";
        a.long_desc["fr-FR"] = "\"VRAI\" L'élément lui-même n'est pas montré. \"FAUX\" ou Vide = L'élément lui-même est aussi montré.";
      
          fd.arg_pool["exclusive"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "hide";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Hide";
        a.short_desc["de-DE"] = "Verborgen";
        a.short_desc["fr-FR"] = "Il masque de la sélection soit les éléments de base ( =1 )\nsoit les consolidations ( = 2).";
        a.long_desc["en"] = "This cireteria works only with Element. 1 = basic elements will be blanked out. 2 = consolidated elements will be blanked out.";
        a.long_desc["de-DE"] = "Kann nur mit Element zusammen verwendet werden. 1 = Basiselemente werden ausgeblendet. 2 = Konsolidierte Elemente werden ausgeblendet";
        a.long_desc["fr-FR"] = "Ne peut être utilisé uniquement qu’avec Élément. 1 = éléments de base sont cachés. 2 = éléments consolidés sont cachés. Vide = Rien n'est caché.";
      
          fd.arg_pool["hide"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_elem";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Revolve elem";
        a.short_desc["de-DE"] = "Wiederholungselement";
        a.short_desc["fr-FR"] = "Des éléments qui ne sont pas au\nniveau de 'Revolve element' seront effacés du sousensemble.";
        a.long_desc["en"] = "This criteria do not work with Element. Elements, which are not at level of REVOLVE ELEMENT will be removed.";
        a.long_desc["de-DE"] = "Kann nicht zusammen mit Element verwendet werden. Elemente, die nicht auf dem Level vom Wiederholungselement sind werden entfernt";
        a.long_desc["fr-FR"] = "Ne peut pas être utilisé avec Élément. Des éléments qui ne sont au niveau de « Rotation_elem » sont supprimés.";
      
          fd.arg_pool["revolve_elem"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_count";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Revolve count";
        a.short_desc["de-DE"] = "Wiederholungsanzahl";
        a.short_desc["fr-FR"] = "'Revolve count'  détermine de quelle longueur doit être exactement la\nliste - qui se répète (revolving).";
        a.long_desc["en"] = "Defines the length of the revolving list (also without REVOLVE-arguments possible). List length responds to the entered number.";
        a.long_desc["de-DE"] = "Bestimmt die Länge der sich wiederholenden Liste (auch ohne andere REVOLVE-Argumente möglich). Listenlänge entspricht der eingegebenen Zahl";
        a.long_desc["fr-FR"] = "Définit la longueur de la liste récurrente (également possible sans arguments « Rotation_elem »). Liste correspond au nombre indiqué.";
      
          fd.arg_pool["revolve_count"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "revolve_add";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Revolve add";
        a.short_desc["de-DE"] = "Wiederholungszugabe";
        a.short_desc["fr-FR"] = "Montre en outre les éléments avec un niveau plus bas (= 1) ou plus haut (= 2).";
        a.long_desc["en"] = "Shows  in addition elements with higher level (REVOLVE ADD = 1) or with a lower level (REVOLVE ADD = 2).";
        a.long_desc["de-DE"] = "Zeigt zusätzlich die Elemente mit höherem Level (REVOLVE ADD = 1) bzw. mit niedrigerem Level (REVOLVE ADD = 2) an";
        a.long_desc["fr-FR"] = "Montre les éléments avec le niveau le plus haut (Rotation ADD = 1) ou avec le niveau le plus bas (Rotation ADD = 2)";
      
          fd.arg_pool["revolve_add"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level_start";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Start level";
        a.short_desc["de-DE"] = "Startlevel";
        a.short_desc["fr-FR"] = "Les éléments qui ne correspondent pas au minimum au\nniveau de 'Level start'  et au maximum au niveau de 'End level' seront supprimés.";
        a.long_desc["en"] = "Beginning of the hierarchical choice at level of this element (if empty, no hierarchical choice).";
        a.long_desc["de-DE"] = "Beginn der hierarchischen Auswahl auf Ebene dieses Elements (falls leer, keine hierarchische Auswahl)";
        a.long_desc["fr-FR"] = "Début de la sélection hiérarchique au niveau de l’élément (si vide, pas de sélection hiérarchique)";
      
          fd.arg_pool["level_start"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "level_end";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "End level";
        a.short_desc["de-DE"] = "Endlevel";
        a.short_desc["fr-FR"] = "Les éléments qui ne correspondent pas au minimum au\nniveau de 'Level start'  et au maximum au niveau de 'End level' seront supprimés.";
        a.long_desc["en"] = "The end of the hierarchical choice at level ot this element (if empty, until the top element)";
        a.long_desc["de-DE"] = "Ende der hierarchischen Auswahl auf Ebene dieses Elements (falls leer, bis zum Topelement)";
        a.long_desc["fr-FR"] = "Fin de la sélection hiérarchique au niveau de l’élément (si vide, jusqu’à l’élément Top)";
      
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
        fd.short_desc["en"] = "A data value will be investigated for each element of a subset. This value can be from type of numeric or string.";
        fd.short_desc["de-DE"] = "Ermittelt für jedes Element eines Subsets einen Datenwert. Der Wert kann numerisch oder ein String sein";
        fd.short_desc["fr-FR"] = "Calcule pour chaque élément d’un sous-ensemble une valeur de données. La valeur peut être numérique ou un String.";
        fd.long_desc["en"] = "A data value will be investigated for each element of a subset. This value can be from type of numeric or string.";
        fd.long_desc["de-DE"] = "Ermittelt für jedes Element eines Subsets einen Datenwert. Der Wert kann numerisch oder ein String sein";
        fd.long_desc["fr-FR"] = "Calcule pour chaque élément d’un sous-ensemble une valeur de données. La valeur peut être numérique ou un String.";
        {
          ArgumentDocumentation a;
    
          a.name = "subcube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Subcube";
        a.short_desc["de-DE"] = "Subcube";
        a.short_desc["fr-FR"] = "PALO.SUBCUBE() est lors d l’utilisation de DFilter une indication nécessaire. Les arguments de PALO.SUBCUBE() sont les noms du cube et un élément de chaque dimension sauf la dimension qui est déjà définie par le sous-ensemble.";
        a.long_desc["en"] = "Palo.Subcube is necassary for DFilter. Arguments are cube name and its dimensions without the Dimensionwhich is included in the subset. This one has to be empty.";
        a.long_desc["de-DE"] = "Palo.Subcube ist für DFilter notwendig. Die Argumente sind der Name des Würfels und seine Dimensionen, ohne die Dimension, die durch das Subset abgedeckt wird. Diese Stelle bleibt leer";
        a.long_desc["fr-FR"] = "Palo.Subcube est nécessaire pour PALO.DFILTER. Les arguments sont le nom du cube et ses dimensions sans la dimension qui est recouverte par la feuille. Cette dernière reste vide.";
      
          fd.arg_pool["subcube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "operations";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Operations";
        a.short_desc["de-DE"] = "Operationen";
        a.short_desc["fr-FR"] = "Les valeurs déterminées pour chaque élément sont vérifiées avec\nle remplissage des critères.\nOpérateurs possibles : = ; < ; > ; <= ; >= ; <>";
        a.long_desc["en"] = "Designation of criteria for the defined values of each element . Possible operators are \" <,>,<>,= \"";
        a.long_desc["de-DE"] = "Damit wird bestimmt, welche Kriterien auf die für jedes Element ermittelten Werte angewendet werden. Mögliche Operatoren sind \" <,>,<>,= \"";
        a.long_desc["fr-FR"] = "Il sera ainsi défini quels critères sont utilisés pour les valeurs calculées pour chaque élément. Les opérateurs possibles sont &lt;,&gt;,&lt;&gt;,=\"";
      
          fd.arg_pool["operations"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "top";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Top";
        a.short_desc["de-DE"] = "Top";
        a.short_desc["fr-FR"] = "Dans le cas où une\nvaleur TOP en nombres entiers est transmise, seuls les premiers\néléments TOP avec les valeurs les plus élevées seront affichés.";
        a.long_desc["en"] = "Optional. In case an integer value TOP is passed, only a number of TOP elements with the highest values are displayed. If the argument is left blank, the elements will not be restricted.";
        a.long_desc["de-DE"] = "Optional. Falls hier ein ganzzahliger Wert TOP übergeben wird, werden lediglich die ersten TOP Elemente mit den größten Werten gezeigt. Wenn das Argument leer bleibt, werden die Elemente nicht weiter eingeschränkt";
        a.long_desc["fr-FR"] = "Optionel. Si une valeur TOP en nombre entiers est rendue, seuls les premiers éléments TOP avec les plus grandes valeurs sont affichés. Si l’argument reste vide, les éléments ne seront plus restreints.";
      
          fd.arg_pool["top"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "upper_percentage";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Upper percentage";
        a.short_desc["de-DE"] = "Oberer Prozentbereich";
        a.short_desc["fr-FR"] = "Pourcentage supérieur";
        a.long_desc["en"] = "If a numeric value between 1 and 99 is entered here, when only those largest elements are selected, whose total value is closest to the limit. The selection starts at the largest element, adds the second largest, etc.";
        a.long_desc["de-DE"] = "Falls hier ein numerischer Wert zwischen 1 und 99 (inklusive) eingetragen wird, so werden nur diejenigen größten Elemente gewählt, deren Gesamtwert dem Grenzwert am nächsten kommt. Die Selektion beginnt beim größten Element";
        a.long_desc["fr-FR"] = "Avec des valeurs numériques de 1 à 99, il est possible de choisir des éléments dont les valeurs cumulées rendent une valeur totale inférieure à la valeur limite. La sélection commence par la valeur la plus grande.";
      
          fd.arg_pool["upper_percentage"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "lower_percentage";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Lower percentage";
        a.short_desc["de-DE"] = "Unterer Prozentbereich";
        a.short_desc["fr-FR"] = "Pourcentage inférieur";
        a.long_desc["en"] = "If a numeric value between 1 and 99 is entered here, when only those smallest elements are selected, whose total value is closest to the limit. The selection starts at the smallest element, adds the second smallest, etc.";
        a.long_desc["de-DE"] = "Falls hier ein numerischer Wert  zwischen 1 und 99 (inklusive) eingetragen wird, so werden nur diejenigen kleinsten Elemente gewählt, deren Gesamtwert dem Grenzwert am nächsten kommt. Die Selektion beginnt beim kleinsten Element, addiert dazu";
        a.long_desc["fr-FR"] = "Valeurs numériques de  1 à 99. Si la valeur est par exemple indiquée, tous les éléments cumulés &lt; = 20% seront sélectionnés. La sélection commence par la plus petite valeur.";
      
          fd.arg_pool["lower_percentage"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cell_operator";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cell operator";
        a.short_desc["de-DE"] = "Zelloperator";
        a.short_desc["fr-FR"] = "Dans le cas où une valeur est indiquée, l’opérateur correspondant est appliqué à chaque Slice.";
        a.long_desc["en"] = "Will be applied to each slice. Operators: 0/empty = SUM, 1=ALL, 2=AVERAGE, 3=MAXIMUM, 4=any, 5=MINIMUM, 7=TEXT. Only elements will be returned, not the values.";
        a.long_desc["de-DE"] = "Wird auf den Slice angewendet. Operatoren: 0/leer = SUMME, 1=ALLE, 2=MITTELWERT, 3=MAXIMUM, 4=Beliebig, 5=MINIMUM, 7=TEXT. Zurückgegeben werden die Elemente – nicht die Werte";
        a.long_desc["fr-FR"] = "Est utilisé sur le Slice. Opérateurs: 0/vide = SOMME, 1=TOUS, 2=MOYENNE, 3=MAXIMUM,4=quelconque, 5=MINIMUM, 7=TEXTE Les éléments sont renvoyés – pas les valeurs";
      
          fd.arg_pool["cell_operator"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "no_rules";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "No rules.";
        a.short_desc["de-DE"] = "Ohne Regeln";
        a.short_desc["fr-FR"] = "No rules";
        a.long_desc["en"] = "blank/FALSE = Takes cell content with the applied Rules. TRUE = Rules are not applied.";
        a.long_desc["de-DE"] = "Leer/FALSCH = Nehme Zellinhalte mit Berücksichtigung der Rules. WAHR = Berücksichtige keine Rules";
        a.long_desc["fr-FR"] = "Vide/Faux= contenus de cellule extraits compte tenu des Enterprise-Rules. Vrai = ne tient pas compte des Enterprise-Rules.";
      
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
        fd.short_desc["en"] = "Is necessary for Palo DFilter. The function gets the slice as an argument. The Dimensionof the subset has to be empty. The respectivly element will be inserted here. For each Dimensioncan be indicated any elements.";
        fd.short_desc["de-DE"] = "Ist erforderlich für Palo DFilter. Die Funktion bekommt den Slice als Argument. Die Dimensiondes SubSets wird leer gelassen. Hier wird dann das jeweilige Element intern eingesetzt. Man kann für jede Dimensionbeliebig viele Elemente angeben";
        fd.short_desc["fr-FR"] = "Est indispensable pour Palo DFilter. Fonction qui obtient le Slice en tant qu’argument. La dimension du sous-ensemble est laissée vide. Chaque élément est constitué ainsi en interne. Il est possible pour chaque dimension d’indiquer autant d’éléments que souhaités. Au moins est cependant nécessaire (TODO: ou \"*\" pour tous).";
        fd.long_desc["en"] = "This function is necessary for Palo DFilter. The function gets the slice as an argument. The Dimensionof the subset has to be empty. The respectivly element will be inserted here. For each Dimensioncan be indicated any elements.";
        fd.long_desc["de-DE"] = "Diese Funktion ist erforderlich für Palo DFilter. Die Funktion bekommt den Slice als Argument . Die Dimension des SubSets wird leer gelassen. Hier wird dann das jeweilige Element intern eingesetzt. Man kann für jede Dimension beliebig viele El";
        fd.long_desc["fr-FR"] = "Est indispensable pour Palo DFilter. Fonction qui obtient le Slice en tant qu’argument. La dimension du sous-ensemble est laissée vide. Chaque élément est constitué ainsi en interne. Il est possible pour chaque dimension d’indiquer autant d’éléments que souhaités. Au moins est cependant nécessaire (TODO: ou \"*\" pour tous).";
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Nom du cube.";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "element";
          a.repeat = (bool)true;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "The names of the Dimensions, that form the subcube, so that the elements were delimitated which have to be filtered. The place, where normaly the Dimensionfrom the subset stands, has to be empty.";
        a.long_desc["de-DE"] = "Die Namen der Dimensionen, die den Subcube bildet und somit die Elemente einschränkt, die gefiltert werden sollen. Der Platz der Dimensiondes Subset wird leer gelassen";
        a.long_desc["fr-FR"] = "Nom des dimensions qui forme le sous-ensemble et ainsi limite les éléments qui doivent être triés sachant que la place pour la dimension du sous-ensemble est laissée vide.";
      
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
        fd.short_desc["en"] = "Close a connection.";
        fd.short_desc["de-DE"] = "Trennt eine Verbindung";
        fd.short_desc["fr-FR"] = "Déconnecte une connexion.";
        fd.long_desc["de-DE"] = "Trennt eine Verbindung";
        fd.long_desc["fr-FR"] = "Déconnecte une connexion.";
        {
          ArgumentDocumentation a;
    
          a.name = "connection";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Connection";
        a.short_desc["de-DE"] = "Verbindung";
        a.short_desc["fr-FR"] = "Connexion";
        a.long_desc["en"] = "The connection to be closed.";
        a.long_desc["de-DE"] = "Die zu trennende Verbindung";
        a.long_desc["fr-FR"] = "La connexion qui sera être coupé.";
      
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
        fd.short_desc["en"] = "Clears a cube or part of it.";
        fd.short_desc["de-DE"] = "Löscht einen Würfel oder einen Teil davon";
        fd.short_desc["fr-FR"] = "Vide un cube ou une partie de celui-ci.";
        fd.long_desc["en"] = "Clears a cube or part of it.";
        fd.long_desc["de-DE"] = "Löscht einen Würfel oder einen Teil davon";
        fd.long_desc["fr-FR"] = "Vide un cube ou une partie de celui-ci.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
          fd.arg_pool["cube"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "area";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Area to be cleared.";
        a.short_desc["de-DE"] = "Zu löschender Bereich";
        a.short_desc["fr-FR"] = "Plage à supprimer.";
        a.long_desc["en"] = "Area to be cleared.";
        a.long_desc["de-DE"] = "Zu löschender Bereich";
        a.long_desc["fr-FR"] = "Plage à supprimer.";
      
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
        fd.short_desc["en"] = "Clears the elements of a dimension.";
        fd.short_desc["de-DE"] = "Löscht die Elemente einer Dimension";
        fd.short_desc["fr-FR"] = "Efface les éléments d'une dimension.";
        fd.long_desc["en"] = "Clears the elements of a dimension.";
        fd.long_desc["de-DE"] = "Löscht die Elemente einer Dimension";
        fd.long_desc["fr-FR"] = "Efface les éléments d'une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the Dimension whose elements are to be deleted.";
        a.long_desc["de-DE"] = "Name der Dimension, deren Elemente gelöscht werden sollen";
        a.long_desc["fr-FR"] = "Name of the Dimensionwhose elements are to be deleted.";
      
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
        fd.short_desc["en"] = "Add a database.";
        fd.short_desc["de-DE"] = "Eine Datenbank hinzufügen";
        fd.short_desc["fr-FR"] = "Ajoute une base de données.";
        fd.long_desc["en"] = "Add a database.";
        fd.long_desc["de-DE"] = "Eine Datenbank hinzufügen";
        fd.long_desc["fr-FR"] = "Ajoute une base de données.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Type";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Type";
        a.short_desc["de-DE"] = "Typ";
        a.short_desc["fr-FR"] = "Type";
        a.long_desc["en"] = "Type of the Database (0=normal,1=system,3=userinfo)";
        a.long_desc["de-DE"] = "Typ der Datenbank (0=normal,1=system,3=userinfo)";
        a.long_desc["fr-FR"] = "Type de la base de données (0=normal,1=système,3=info d'utilisateur)";
      
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
        fd.short_desc["en"] = "Delete a database.";
        fd.short_desc["de-DE"] = "Löscht eine Datenbank";
        fd.short_desc["fr-FR"] = "Supprime une base de données.";
        fd.long_desc["en"] = "Delete a database.";
        fd.long_desc["de-DE"] = "Löscht eine Datenbank";
        fd.long_desc["fr-FR"] = "Supprime une base de données.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
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
        fd.short_desc["en"] = "Load a cube.";
        fd.short_desc["de-DE"] = "Ladet einen Würfel";
        fd.short_desc["fr-FR"] = "Charge un cube.";
        fd.long_desc["en"] = "Load a cube.";
        fd.long_desc["de-DE"] = "Ladet einen Würfel";
        fd.long_desc["fr-FR"] = "Charge un cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "Unload a cube.";
        fd.short_desc["de-DE"] = "Leert einen Würfel";
        fd.short_desc["fr-FR"] = "Vide un cube.";
        fd.long_desc["en"] = "Unload a cube.";
        fd.long_desc["de-DE"] = "Leert einen Würfel";
        fd.long_desc["fr-FR"] = "Vide un cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "Add a cube.";
        fd.short_desc["de-DE"] = "Fügt einen Würfel hinzu";
        fd.short_desc["fr-FR"] = "Ajoute un cube.";
        fd.long_desc["en"] = "Add a cube.";
        fd.long_desc["de-DE"] = "Fügt einen Würfel hinzu";
        fd.long_desc["fr-FR"] = "Ajoute un cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "Delete a cube.";
        fd.short_desc["de-DE"] = "Löscht einen Würfel";
        fd.short_desc["fr-FR"] = "Supprime un cube.";
        fd.long_desc["en"] = "Delete a cube.";
        fd.long_desc["de-DE"] = "Löscht einen Würfel";
        fd.long_desc["fr-FR"] = "Supprime un cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "Adds a dimension.";
        fd.short_desc["de-DE"] = "Fügt eine Dimensionhinzu";
        fd.short_desc["fr-FR"] = "Ajoute une dimension.";
        fd.long_desc["en"] = "Adds a dimension.";
        fd.long_desc["de-DE"] = "Fügt eine Dimensionhinzu";
        fd.long_desc["fr-FR"] = "Ajoute une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the Dimensionthat will be added.";
        a.long_desc["de-DE"] = "Name der Dimension, die hinzugefügt wird";
        a.long_desc["fr-FR"] = "Nom de la dimension qui sera ajouté.";
      
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
        fd.short_desc["en"] = "Deletes a dimension.";
        fd.short_desc["de-DE"] = "Löscht eine Dimension";
        fd.short_desc["fr-FR"] = "Supprime une dimension.";
        fd.long_desc["en"] = "Deletes a dimension.";
        fd.long_desc["de-DE"] = "Löscht eine Dimension";
        fd.long_desc["fr-FR"] = "Supprime une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the Dimension which should be deleted.";
        a.long_desc["de-DE"] = "Name der Dimension, die gelöscht werden soll";
        a.long_desc["fr-FR"] = "Name of the Dimensionthat should be deleted.";
      
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
        fd.short_desc["en"] = "Begins request collect.";
        fd.short_desc["de-DE"] = "Startet die Abfrage";
        fd.short_desc["fr-FR"] = "Commence la demande.";
        fd.long_desc["en"] = "Begins request collect.";
        fd.long_desc["de-DE"] = "Startet die Abfrage";
        fd.long_desc["fr-FR"] = "Commence la demande.";
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
        fd.short_desc["en"] = "Ends request collect.";
        fd.short_desc["de-DE"] = "Beendet Abfrage";
        fd.short_desc["fr-FR"] = "Arrête la demande.";
        fd.long_desc["en"] = "End request collect.";
        fd.long_desc["de-DE"] = "Beendet Abfrage";
        fd.long_desc["fr-FR"] = "Arrête la demande.";
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
        fd.short_desc["en"] = "Rename a dimension.";
        fd.short_desc["de-DE"] = "Benennt eine Dimensionum";
        fd.short_desc["fr-FR"] = "Renomme une dimension.";
        fd.long_desc["en"] = "Rename a dimension.";
        fd.long_desc["de-DE"] = "Benennt eine Dimensionum";
        fd.long_desc["fr-FR"] = "Renomme une dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "old_dim_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Current Dimensionname.";
        a.short_desc["de-DE"] = "Aktueller Name der Dimension";
        a.short_desc["fr-FR"] = "Actuel nom de la dimension.";
        a.long_desc["en"] = "Name of the Dimension which should be renamed.";
        a.long_desc["de-DE"] = "Name der Dimension, die umbenannt werden soll";
        a.long_desc["fr-FR"] = "Nom de la dimension qui devrait être renommé.";
      
          fd.arg_pool["old_dim_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "new_dim_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "New Dimensionname.";
        a.short_desc["de-DE"] = "Neuer Dimensionsname";
        a.short_desc["fr-FR"] = "Nouveau nom de la dimension.";
        a.long_desc["en"] = "New Dimensionname";
        a.long_desc["de-DE"] = "Neuer Dimensionsname";
        a.long_desc["fr-FR"] = "Nouveau nom de la dimension.";
      
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
        fd.short_desc["en"] = "Rename a cube.";
        fd.short_desc["de-DE"] = "Benennt einen Würfel um";
        fd.short_desc["fr-FR"] = "Renomme un cube.";
        fd.long_desc["en"] = "Rename a cube.";
        fd.long_desc["de-DE"] = "Benennt einen Würfel um";
        fd.long_desc["fr-FR"] = "Renomme un cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "old_cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Current cube name.";
        a.short_desc["de-DE"] = "Aktueller Würfelname";
        a.short_desc["fr-FR"] = "Le nom actuel du cube.";
        a.long_desc["en"] = "Name of the cube which should be renamed.";
        a.long_desc["de-DE"] = "Name des Würfels, der umbenannt werden soll";
        a.long_desc["fr-FR"] = "Le nom du cube qui devrait être renommé.";
      
          fd.arg_pool["old_cube_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "new_cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "New cube name.";
        a.short_desc["de-DE"] = "Neuer Name des Würfels";
        a.short_desc["fr-FR"] = "Le nom nouveau du cube.";
        a.long_desc["en"] = "New cube name.";
        a.long_desc["de-DE"] = "Neuer Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom nouveau du cube.";
      
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
        fd.short_desc["en"] = "Shows cube info.";
        fd.short_desc["de-DE"] = "Zeigt Würfelinformationen";
        fd.short_desc["fr-FR"] = "Affiche des informations du cube.";
        fd.long_desc["en"] = "Shows cube info.";
        fd.long_desc["de-DE"] = "Zeigt Würfelinformationen";
        fd.long_desc["fr-FR"] = "Affiche des informations du cube.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "database_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Name of the database.";
        a.short_desc["de-DE"] = "Name der Datenbank";
        a.short_desc["fr-FR"] = "Le nom de la base de donnée.";
        a.long_desc["en"] = "Name of the database.";
        a.long_desc["de-DE"] = "Name der Datenbank";
        a.long_desc["fr-FR"] = "Le nom de la base de donnée.";
      
          fd.arg_pool["database_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "cube_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Name of the cube.";
        a.short_desc["de-DE"] = "Name des Würfels";
        a.short_desc["fr-FR"] = "Le nom du cube.";
        a.long_desc["en"] = "Name of the cube.";
        a.long_desc["de-DE"] = "Name des Würfels";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "Shows Dimensioninfo.";
        fd.short_desc["de-DE"] = "Zeigt Dimensionsinformationen";
        fd.short_desc["fr-FR"] = "Affiche info de la dimension.";
        fd.long_desc["en"] = "Shows Dimensioninfo.";
        fd.long_desc["de-DE"] = "Zeigt Dimensionsinformationen";
        fd.long_desc["fr-FR"] = "Affiche info de la dimension.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "database_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Database name.";
        a.short_desc["de-DE"] = "Name der Datenbank";
        a.short_desc["fr-FR"] = "Nom de la base de données.";
        a.long_desc["en"] = "Name of the database.";
        a.long_desc["de-DE"] = "Name der Datenbank";
        a.long_desc["fr-FR"] = "Name of the database";
      
          fd.arg_pool["database_name"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "dimension_name";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimensionname.";
        a.short_desc["de-DE"] = "Name der Dimension";
        a.short_desc["fr-FR"] = "Nom de la dimension.";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
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
        fd.short_desc["en"] = "Remove connection.";
        fd.short_desc["de-DE"] = "Trennt die Verbindung";
        fd.short_desc["fr-FR"] = "Couper la connexion.";
        fd.long_desc["en"] = "Remove connection.";
        fd.long_desc["de-DE"] = "Trennt die Verbindung";
        fd.long_desc["fr-FR"] = "Couper la connexion.";
        {
          ArgumentDocumentation a;
    
          a.name = "cname";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Connection Name";
        a.short_desc["de-DE"] = "Verbindungsname";
        a.short_desc["fr-FR"] = "Nom de la connexion";
        a.long_desc["en"] = "Connection Name";
        a.long_desc["de-DE"] = "Verbindungsname";
        a.long_desc["fr-FR"] = "Nom de la connexion";
      
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
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = "Returns all childs and grandchilds";
        fd.short_desc["de-DE"] = "Listet alle Kinder sowie Kindeskinder auf";
        fd.short_desc["fr-FR"] = "Liste tous les descendants.";
        fd.long_desc["en"] = "Returns all childs and grandchilds";
        fd.long_desc["de-DE"] = "Listet alle Kinder sowie Kindeskinder auf";
        fd.long_desc["fr-FR"] = "Liste tous les descendants.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Element";
        a.long_desc["de-DE"] = "Elementname";
        a.long_desc["fr-FR"] = "Élément";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.xl_doc.xl_special = (bool)1;
        fd.xl_doc.xl_func_type = 1;
        fd.xl_doc.xl_volatile = (bool)0;
        fd.xl_doc.is_xl_function = true;
        fd.short_desc["en"] = "Returns all ancestors of the given element.";
        fd.short_desc["de-DE"] = "Listet alle Ahnen (Elternelemente aller Stufen) des angegeben Elements auf";
        fd.short_desc["fr-FR"] = "Listes de tous les ancêtres de l'élément spécifié";
        fd.long_desc["en"] = "Returns all ancestors of the given element.";
        fd.long_desc["de-DE"] = "Listet alle Ahnen (Elternelemente aller Stufen) des angegeben Elements auf";
        fd.long_desc["fr-FR"] = "Listes de tous les ancêtres de l'élément spécifié";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Element";
        a.long_desc["de-DE"] = "Elementname";
        a.long_desc["fr-FR"] = "Élément";
      
          fd.arg_pool["Element"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
        fd.short_desc["en"] = "FPaloGetCubeId";
        fd.short_desc["de-DE"] = "Liefert die ID des Würfels";
        fd.short_desc["fr-FR"] = "FPaloGetCubeId";
        fd.long_desc["en"] = "FPaloGetCubeId";
        fd.long_desc["de-DE"] = "Liefert die ID des Würfels";
        fd.long_desc["fr-FR"] = "FPaloGetCubeId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "FPaloGetCubeName";
        fd.short_desc["de-DE"] = "Liefert den Namen des Würfels";
        fd.short_desc["fr-FR"] = "FPaloGetCubeName";
        fd.long_desc["en"] = "FPaloGetCubeName";
        fd.long_desc["de-DE"] = "Liefert den Namen des Würfels";
        fd.long_desc["fr-FR"] = "FPaloGetCubeName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Cube";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Cube";
        a.short_desc["de-DE"] = "Würfel";
        a.short_desc["fr-FR"] = "Cube";
        a.long_desc["en"] = "Cube";
        a.long_desc["de-DE"] = "Würfel";
        a.long_desc["fr-FR"] = "Le nom du cube.";
      
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
        fd.short_desc["en"] = "FPaloGetElementId";
        fd.short_desc["de-DE"] = "Liefert die ID des Elements";
        fd.short_desc["fr-FR"] = "FPaloGetElementId";
        fd.long_desc["en"] = "FPaloGetElementId";
        fd.long_desc["de-DE"] = "Liefert die ID des Elements";
        fd.long_desc["fr-FR"] = "FPaloGetElementId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Element";
        a.long_desc["de-DE"] = "Elementname";
        a.long_desc["fr-FR"] = "Élément";
      
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
        fd.short_desc["en"] = "FPaloGetElementName";
        fd.short_desc["de-DE"] = "Liefert den Namen des Elements";
        fd.short_desc["fr-FR"] = "FPaloGetElementName";
        fd.long_desc["en"] = "FPaloGetElementName";
        fd.long_desc["de-DE"] = "Liefert den Namen des Elements";
        fd.long_desc["fr-FR"] = "FPaloGetElementName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Element";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Element";
        a.short_desc["de-DE"] = "Element";
        a.short_desc["fr-FR"] = "Élément";
        a.long_desc["en"] = "Element";
        a.long_desc["de-DE"] = "Elementname";
        a.long_desc["fr-FR"] = "Élément";
      
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
        fd.short_desc["en"] = "FPaloGetDimensionId";
        fd.short_desc["de-DE"] = "Liefert die ID der Dimension";
        fd.short_desc["fr-FR"] = "FPaloGetDimensionId";
        fd.long_desc["en"] = "FPaloGetDimensionId";
        fd.long_desc["de-DE"] = "Liefert die ID der Dimension";
        fd.long_desc["fr-FR"] = "FPaloGetDimensionId";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
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
        fd.short_desc["en"] = "FPaloGetDimensionName";
        fd.short_desc["de-DE"] = "Liefert den Namen der Dimension";
        fd.short_desc["fr-FR"] = "FPaloGetDimensionName";
        fd.long_desc["en"] = "FPaloGetDimensionName";
        fd.long_desc["de-DE"] = "Liefert den Namen der Dimension";
        fd.long_desc["fr-FR"] = "FPaloGetDimensionName";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Dimension";
        a.long_desc["de-DE"] = "Dimensionsname";
        a.long_desc["fr-FR"] = "Le nom de la dimension.";
      
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
        fd.short_desc["en"] = "Get a list of all elements with the matching alias.";
        fd.short_desc["de-DE"] = "Liefert eine Liste mit allen Elementen die das angegebene Alias haben";
        fd.short_desc["fr-FR"] = "Retourne une liste contenant tous les éléments ont l'alias spécifié.";
        fd.long_desc["en"] = "Get a list of all elements with the matching alias.";
        fd.long_desc["de-DE"] = "Liefert eine Liste mit allen Elementen die das angegebene Alias haben";
        fd.long_desc["fr-FR"] = "Retourne une liste contenant tous les éléments ont l'alias spécifié.";
        {
          ArgumentDocumentation a;
    
          a.name = "Server/Database";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Server/Database";
        a.short_desc["de-DE"] = "Server/Datenbank";
        a.short_desc["fr-FR"] = "Serveur/Base de données";
        a.long_desc["en"] = "Server/Database";
        a.long_desc["de-DE"] = "Server/Datenbank";
        a.long_desc["fr-FR"] = "Serveur/Base de données";
      
          fd.arg_pool["Server/Database"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Dimension";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Dimension";
        a.short_desc["de-DE"] = "Dimension";
        a.short_desc["fr-FR"] = "Dimension";
        a.long_desc["en"] = "Name of the dimension.";
        a.long_desc["de-DE"] = "Name der Dimension.";
        a.long_desc["fr-FR"] = "Nom de la dimension";
      
          fd.arg_pool["Dimension"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Attribute";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Attribute";
        a.short_desc["de-DE"] = "Attribut";
        a.short_desc["fr-FR"] = "Attribut";
        a.long_desc["en"] = "Name of the Attribute.";
        a.long_desc["de-DE"] = "Name des Attributs";
        a.long_desc["fr-FR"] = "Nom  de l'attribut.";
      
          fd.arg_pool["Attribute"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "AliasValue";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Alias";
        a.short_desc["de-DE"] = "Alias";
        a.short_desc["fr-FR"] = "Alias";
        a.long_desc["en"] = "Name of the alias you want to look for.";
        a.long_desc["de-DE"] = "Name des Alias";
        a.long_desc["fr-FR"] = "Nom de l'alias pour qui doit être recherchée";
      
          fd.arg_pool["AliasValue"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Index";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Index";
        a.short_desc["de-DE"] = "Index";
        a.short_desc["fr-FR"] = "Index";
        a.long_desc["en"] = "Index of the element in the result, which you want to show. 0 or empty for all elements.";
        a.long_desc["de-DE"] = "Index des Ergebniselements, das angezeigt werden soll. 0 oder leer für alle Elemente";
        a.long_desc["fr-FR"] = "Index de l'élément qui doit être affiché. 0 ou vide pour tous les éléments.";
      
          fd.arg_pool["Index"] = a;
        }
    
        {
          ArgumentDocumentation a;
    
          a.name = "Empty String";
          a.repeat = (bool)false;
          a.type = ArgumentDocumentation::getType("string");
    
        a.short_desc["en"] = "Empty String";
        a.short_desc["de-DE"] = "Leerer String";
        a.short_desc["fr-FR"] = "Chaîne vide";
        a.long_desc["en"] = "Enter TRUE to suppress error messages. Otherwise, leave blank.";
        a.long_desc["de-DE"] = "WAHR eingeben, wenn eine eventuelle Fehlermeldung unterdrückt werden soll. Sonst leer lassen";
        a.long_desc["fr-FR"] = "Ce paramètre sera laissé vide.";
      
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
    