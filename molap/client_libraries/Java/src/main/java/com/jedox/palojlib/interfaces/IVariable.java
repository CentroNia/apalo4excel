/**
 * 
 */
package com.jedox.palojlib.interfaces;

/**
 * represent a name/value pair that can be used in some API methods (e.g. {@link IDimension#evaluateGlobalSubset(String, com.jedox.palojlib.main.Variable[])}})
 * @author khaddadin
 *
 */
public interface IVariable {
	
	/**
	 * get the name
	 * @return the variable name
	 */
	public String getName();
	
	/**
	 * get the value 
	 * @return the variable value
	 */
	public String getValue();
	


}
