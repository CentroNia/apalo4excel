<?xml version="1.0" encoding="utf-8"?>
<stylesheet version="1.0" 
            xmlns="http://www.w3.org/1999/XSL/Transform"
            xmlns:doc="http://tempuri.org/Palo/SpreadsheetFuncs/Documentation.xsd">
  <output method="text" indent="no"/>

  <template match="doc:Function/doc:LongDescription">
    <call-template name="description">
      <with-param name="type" select="'long'"/>
      <with-param name="base" select="'fd'"/>
    </call-template>
  </template>

  <template match="doc:Function/doc:ShortDescription">
    <call-template name="description">
      <with-param name="type" select="'short'"/>
      <with-param name="base" select="'fd'"/>
    </call-template>
  </template>

  <template match="doc:Function/doc:ArgumentPool/doc:Argument/doc:LongDescription">
    <call-template name="description">
      <with-param name="type" select="'long'"/>
      <with-param name="base" select="'a'"/>
    </call-template>
  </template>

  <template match="doc:Function/doc:ArgumentPool/doc:Argument/doc:ShortDescription">
    <call-template name="description">
      <with-param name="type" select="'short'"/>
      <with-param name="base" select="'a'"/>
    </call-template>
  </template>

  <template name="description" priority="-1"  match="doc:ShortDescription|doc:LongDescription">
    <param name="type"/>
    <param name="base"/>
    <for-each select="./doc:Value">
      <text disable-output-escaping="yes">
        </text>
      <value-of disable-output-escaping="yes" select="$base" />
      <text disable-output-escaping="yes">.</text>
      <value-of disable-output-escaping="yes" select="$type" />
      <text disable-output-escaping="yes">_desc["</text>
      <if test="not(@lang)">
        <text disable-output-escaping="yes">en</text>
      </if>
      <if test="@lang">
        <value-of disable-output-escaping="yes" select="@lang"/>
      </if>
      <text disable-output-escaping="yes">"] = L"</text>
      <value-of disable-output-escaping="yes" select="."/>
      <text disable-output-escaping="yes">";</text>
    </for-each>
  </template>

  <template match="doc:ArgumentRef">
    <text disable-output-escaping="yes">
          p.arg_keys.push_back("</text>
    <value-of disable-output-escaping="yes" select="@name"/>
    <text disable-output-escaping="yes">");</text>
  </template>

  <template match="doc:Signature">
    <text disable-output-escaping="yes">
        {
          PrototypeDocumentation p;
    </text>

    <apply-templates/>

    <text disable-output-escaping="yes">
      
          fd.prototypes.push_back(p);
        } 
    </text>
  </template>

  <template match="doc:Argument">
    <text disable-output-escaping="yes">
        {
          ArgumentDocumentation a;
    </text>

    <text disable-output-escaping="yes">
          a.name = "</text>
    <value-of disable-output-escaping="yes" select="@name"/>
    <text disable-output-escaping="yes">";</text>

    <text disable-output-escaping="yes">
          a.repeat = (bool)</text>
    <if test="@repeat">
      <value-of disable-output-escaping="yes" select="@repeat"/>
    </if>
    <if test="not(@repeat)">
      <text disable-output-escaping="yes">false</text>
    </if>
    <text disable-output-escaping="yes">;</text>

    <text disable-output-escaping="yes">
          a.type = ArgumentDocumentation::getType("</text>
    <value-of disable-output-escaping="yes" select="@type"/>
    <text disable-output-escaping="yes">");
    </text>

    <apply-templates/>

    <text disable-output-escaping="yes">
      
          fd.arg_pool["</text>
    <value-of select="@name"/>
    <text disable-output-escaping="yes">"] = a;
        }
    </text>
  </template>

  <template match="doc:ExcelSpecific">
    <text disable-output-escaping="yes">
        
        fd.xl_doc.xl_name = "</text>
    <value-of disable-output-escaping="yes" select="@name"/>
    <text disable-output-escaping="yes">";</text>
    <text disable-output-escaping="yes">
        fd.xl_doc.xl_special = (bool)</text>
    <value-of disable-output-escaping="yes" select="@special"/>
    <text disable-output-escaping="yes">;</text>
    <text disable-output-escaping="yes">
        fd.xl_doc.xl_func_type = </text>
    <value-of disable-output-escaping="yes" select="@func_type"/>
    <text disable-output-escaping="yes">;</text>
    <text disable-output-escaping="yes">
        fd.xl_doc.xl_volatile = (bool)</text>
    <value-of disable-output-escaping="yes" select="@volatile"/>
    <text disable-output-escaping="yes">;</text>
    <text disable-output-escaping="yes">
        fd.xl_doc.is_xl_function = true;</text>
  </template>

  <template match="doc:Function">
    <text disable-output-escaping="yes">
      {
        FunctionDocumentation fd;
    </text>

    <text disable-output-escaping="yes">
        fd.name = "</text>
    <value-of disable-output-escaping="yes" select="@internal_name"/>
    <text disable-output-escaping="yes">";</text>

    <text disable-output-escaping="yes">
        fd.c_name = "</text>
    <value-of disable-output-escaping="yes" select="@c_name"/>
    <text disable-output-escaping="yes">";</text>

    <apply-templates/>

    <text disable-output-escaping="yes">
        functions.push_back(fd);
      }
    </text>
  </template>

  <template match="*|@*|text()">
    <apply-templates select="@*"/>
    <apply-templates/>
  </template>
</stylesheet>