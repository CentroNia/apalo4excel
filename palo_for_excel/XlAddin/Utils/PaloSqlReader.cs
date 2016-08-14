 /* 
 *
 * Copyright (C) 2006-2011 Jedox AG
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License (Version 2) as published
 * by the Free Software Foundation at http://www.gnu.org/copyleft/gpl.html.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for
 * more details.
 *
 * You should have received a copy of the GNU General Public License along with
 * this program; if not, write to the Free Software Foundation, Inc., 59 Temple
 * Place, Suite 330, Boston, MA 02111-1307 USA
 *
 * You may obtain a copy of the License at
 *
 * <a href="http://www.jedox.com/license_palo_bi_suite.txt">
 *   http://www.jedox.com/license_palo_bi_suite.txt
 * </a>
 *
 * If you are developing and distributing open source applications under the
 * GPL License, then you are free to use Palo under the GPL License.  For OEMs,
 * ISVs, and VARs who distribute Palo with their products, and do not license
 * and distribute their source code under the GPL, Jedox provides a flexible
 * OEM Commercial License.
 *
 * \author
 * 
 *
 */
//using Microsoft.Data.Odbc;
using System;
using System.Data;
using System.Data.Odbc;
using System.Runtime.InteropServices;

namespace Apalo.XlAddin.Utils
{
	[ComVisible(false)]
	public class PaloSqlReader : System.IDisposable
	{
		private OdbcConnection cn;
		private OdbcCommand cmd;
		private OdbcDataAdapter da;
		private string tablename;
		private string dsn;
		private string uid;
		private string pwd;
		private string select;
		private int pagesize;
		private int blocknr;
        private long numberrecords;

		public PaloSqlReader(string dsName, string userId, string password, string select, int pageSize)
		{
            this.tablename = "Table";
			this.dsn = dsName;
			this.uid = userId;
			this.pwd = password;
			this.select = select;
			this.pagesize = pageSize;
		}
	
		public long Start(System.Data.DataSet dataSet)
		{
            this.numberrecords = 0;
            if (dataSet == null)
            {
                return -1;
            }

			this.cn = new OdbcConnection("dsn="+this.dsn+";UID="+this.uid+";PWD="+this.pwd+";");

            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_SQL_WAIT);

			if (this.select.Length > 0)
			{
				this.cmd =new OdbcCommand(this.select,this.cn);
				this.da = new OdbcDataAdapter(this.cmd);
				this.da.Fill(dataSet);
                this.numberrecords = dataSet.Tables[0].Rows.Count;
                dataSet.Clear();
                GC.Collect();

				this.da.Fill(dataSet, 0, this.pagesize, this.tablename);
				this.blocknr = 1;
			}

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

    		return this.numberrecords;
		}

		public long Next(System.Data.DataSet dataSet)
		{
            Apalo.XlAddin.Utils.ExcelHelper.SetExcelStatusbar(Apalo.XlAddin.Utils.ResourceInitializer.STATUS_READ_SQL_WAIT);


			this.da.Fill(dataSet, this.pagesize * this.blocknr++, this.pagesize, this.tablename);

            Apalo.XlAddin.Utils.ExcelHelper.ResetExcelStatusbar();

            return this.numberrecords;

		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(disposing == true)
			{
                this.da.Dispose();
                this.cmd.Dispose();
                this.cn.Dispose();
			}
		}
	}
}