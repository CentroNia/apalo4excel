<?xml version="1.0" encoding="utf-8"?>
<stylesheet version="1.0"
            xmlns="http://www.w3.org/1999/XSL/Transform"
            xmlns:doc="http://tempuri.org/Palo/SpreadsheetFuncs/Documentation.xsd">
  <output method="text" indent="no"/>

  <template match="doc:Function">
    <if test="./doc:ExcelSpecific">
      <text disable-output-escaping="yes">
      FUNC_DEFINITION( </text>
      <value-of disable-output-escaping="yes" select="@c_name"/>
      <text disable-output-escaping="yes">, </text>
      <value-of disable-output-escaping="yes" select="@internal_name"/>
      <text disable-output-escaping="yes">, </text>

      <variable name="sigs" select="./doc:Signatures/doc:Signature"/>
      <if test="count($sigs) > 1">
        <text disable-output-escaping="yes">-1</text>
      </if>
      <if test="./doc:ArgumentPool/doc:Argument/@repeat">
        <text disable-output-escaping="yes">-1</text>
      </if>
      <if test="count($sigs) = 1">
        <if test="not(./doc:ArgumentPool/doc:Argument/@repeat)">
          <variable name="args" select="./doc:Signatures/doc:Signature/doc:ArgumentRef"/>
          <value-of select="count($args)"/>
        </if>
      </if>

      <text disable-output-escaping="yes">, </text>
      <if test="./doc:ArgumentPool/doc:Argument/@allow_error">
        <text disable-output-escaping="yes">true</text>
      </if>
      <if test="not(./doc:ArgumentPool/doc:Argument/@allow_error)">
        <text disable-output-escaping="yes">false</text>
      </if>

      <text disable-output-escaping="yes">)</text>
    </if>    
  </template>
</stylesheet>