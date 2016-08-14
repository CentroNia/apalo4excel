/**
 *   @brief <Description of Class>
 *
 *   @file
 *
 *   Copyright (C) 2008-2013 Jedox AG
 *
 *   This program is free software; you can redistribute it and/or modify it
 *   under the terms of the GNU General Public License (Version 2) as published
 *   by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 *   This program is distributed in the hope that it will be useful, but WITHOUT
 *   ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 *   FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 *   more details.
 *
 *   You should have received a copy of the GNU General Public License along with
 *   this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 *   Place, Suite 330, Boston, MA 02111-1307 USA
 *
 *   You may obtain a copy of the License at
*
 *   If you are developing and distributing open source applications under the
 *   GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 *   ISVs, and VARs who distribute Palo with their products, and do not license
 *   and distribute their source code under the GPL, Jedox provides a flexible
 *   OEM Commercial License.
 *
 *	 Exclusive worldwide exploitation right (commercial copyright) has Jedox AG, Freiburg.
 *
 *   @author Kais Haddadin, Jedox AG, Freiburg, Germany
 */

package com.jedox.palojlib.test;

import com.jedox.palojlib.interfaces.ICell;
import com.jedox.palojlib.interfaces.IConnection;
import com.jedox.palojlib.interfaces.IConnectionConfiguration;
import com.jedox.palojlib.interfaces.ICube;
import com.jedox.palojlib.interfaces.IDatabase;
import com.jedox.palojlib.interfaces.IDimension;
import com.jedox.palojlib.interfaces.IElement;
import com.jedox.palojlib.main.*;

public class TestExcessiveRequests {

	@SuppressWarnings("unused")
	public static void main(String[] args) {
		IConnectionConfiguration config = new ConnectionConfiguration();
		TestSettings.getInstance().setConfigFromFile(config);
		TestSettings.getInstance().setSSL();
		//TestSettings.getInstance().setDebugLevel();

		try {
			IConnection con = ConnectionManager.getInstance().getConnection(config);
			con.open();
			
			IDatabase demo = con.getDatabaseByName("Biker");
			ICube sales = demo.getCubeByName("Orders2");
			IDimension[] dims = sales.getDimensions();
			

			IElement[] path = new IElement[dims.length];
			path[0] = dims[0].getElementByName("All Years", false);
			path[1] = dims[1].getElementByName("Year", false);
			path[2] = dims[2].getElementByName("All Products", false);
			path[3] = null;
			path[4] = dims[4].getElementByName("All Channels", false);
			path[5] = dims[5].getElementByName("Variance", false);
			path[6] = dims[6].getElementByName("Gross Profit", false);

			IElement[] dim3Elements = dims[3].getElements(false);
			System.out.println("Number of elements " + dim3Elements.length);
			int count = 0;
			for (int k=0; k<100; k++) {
				for(int i=0;i<dim3Elements.length;i++){
					demo = con.getDatabaseByName("Biker");
					sales = demo.getCubeByName("Orders2");
	                
					path[3] = sales.getDimensions()[3].getElementByName(dim3Elements[i].getName(), false);
					for (int j=0; j<path.length; j++) {
						path[j] =  sales.getDimensions()[j].getElementByName(path[j].getName(), false);
					}
					ICell cell = sales.getCell(path);
					System.out.println("For element " + dim3Elements[i].getName() + " path value is " + cell.getValue());
					count++;
				}
			}
			System.out.println("Number of calls " + count);
			System.out.println("Finished");	
			con.close(true);

			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		

	}

}
