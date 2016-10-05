<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
  <xsl:template match="/">
      <table>
        <th>Customer ID</th><th>Contact Name</th><th>Contact Title</th><th>Company Name</th>
        <xsl:for-each select='//Customers'>
        <xsl:choose>
        <xsl:when test="position() mod 2 = 1">
          <tr bgcolor="Silver">
            <td><xsl:value-of select='CustomerID' /></td>
            <td><xsl:value-of select='ContactName' /></td>
            <td><xsl:value-of select='ContactTitle' /></td>
            <td><xsl:value-of select='CompanyName' /></td>
          </tr>
        </xsl:when>
        <xsl:otherwise>
          <tr bgcolor="White">
            <td><xsl:value-of select='CustomerID' /></td>
            <td><xsl:value-of select='ContactName' /></td>
            <td><xsl:value-of select='ContactTitle' /></td>
            <td><xsl:value-of select='CompanyName' /></td>
          </tr>
        </xsl:otherwise>
        </xsl:choose>
        </xsl:for-each>
    </table>
  </xsl:template>
</xsl:stylesheet>


  