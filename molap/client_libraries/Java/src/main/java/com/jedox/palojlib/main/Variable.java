/**
 * 
 */
package com.jedox.palojlib.main;

import com.jedox.palojlib.interfaces.IVariable;

/**
 * @author khaddadin
 *
 */
public class Variable implements IVariable{
	
	private String name;
	private String value;
	
	public Variable(String name,String value){
		this.name = name;
		this.value = value;
	}
	
	public String getName() {
		return name;
	}

	public String getValue() {
		return value;
	}

}
