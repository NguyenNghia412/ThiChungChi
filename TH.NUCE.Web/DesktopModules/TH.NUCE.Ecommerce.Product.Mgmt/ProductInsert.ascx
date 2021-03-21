<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductInsert.ascx.cs"
    Inherits="TH.NUCE.Web.ProductInsert" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<%@ Register TagPrefix="dnn" TagName="TextEditor" Src="../../controls/TextEditor.ascx" %>
<%@ Register TagPrefix="dnn" TagName="URLControl" Src="../../controls/URLControl.ascx" %>
<%@ Reference Control="~/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ProductInsertSettings.ascx" %>
<style type="text/css">
    .SubHead{width:142px; margin-right:10px; float:left;}  
    
</style>
<script type="text/javascript">
    function textCounter(name, cnt, maxlimit) {
        var cntfield = document.getElementById(cnt);
        var field = document.getElementById(name);
        if (field.value.length > maxlimit) // if too long...trim it!
            field.value = field.value.substring(0, maxlimit);
            // otherwise, update 'characters left' counter
        else
            cntfield.value = maxlimit - field.value.length;
    };
</script>

<style type="text/css">
    td > .dnnTooltip label {
        text-align: left;
    }
</style>
<p align="center" class="Normal" style="color: Red;">
    <asp:Label ID="lblError" runat="server" Visible="True">Thêm mới sản phẩm</asp:Label></p>
<table width="100%">
    <!-- Input Title  -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td style="text-align: left" class="SubHead">
            <b><font size="2" face="Arial">Tên sản phẩm </font></b>
        </td>
        <td colspan="2" width="900px">
            <asp:TextBox ID="txtProductName" Width="85%" runat="server"></asp:TextBox>
        </td>
    </tr>
    <!-- Input Title  -->
    <!-- Input addinfo1 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <%--<dnn:Label ID="lbladdInfo1" runat="server" ControlName="txtaddInfo1" Text="Thẻ từ khóa"
                Suffix=":"></dnn:Label>--%>
            <b><font size="2" face="Arial">Thẻ từ khóa </font></b><font size="2" face="Arial">(</font><input
                type="text" value="67" maxlength="3" size="3" name="q17length0" id="q17length0"
                readonly="" style="width: 21px; padding: 5px 0; border: none; color: red; font-size: 13px;"><font
                    size="2" face="Arial">ký tự)</font><font size="2" face="Arial">:</font><font size="2"
                        face="Arial"> </font><font size="2" face="Arial">
        </td>
        <td colspan="2" width="900px">
            <asp:TextBox ID="txtaddInfo1" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input addinfo2 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <%--<dnn:Label ID="lbladdInfo2" runat="server" ControlName="txtaddInfo2" Text="Thẻ mô tả"
                Suffix=":"></dnn:Label>--%>
            <b><font size="2" face="Arial">Thẻ mô tả </font></b><font size="2" face="Arial">(</font><input
                type="text" value="160" maxlength="3" size="3" name="q17length" id="q17length"
                readonly="" style="width: 21px; padding: 5px 0; border: none; color: red; font-size: 13px;"><font
                    size="2" face="Arial">ký tự</font><font size="2" face="Arial">):</font><b><font size="2"
                        face="Arial"> </font></b><font size="2" face="Arial">
        </td>
        <td colspan="2" width="900px">
            <asp:TextBox ID="txtaddInfo2" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input addinfo3 -->
    <tr style="display: none;">
        <td style="text-align: left" class="SubHead">
            <dnn:Label ID="lblCode" runat="server" ControlName="txtCode" Text="Code" Suffix=":">
            </dnn:Label>
        </td>
        <td colspan="2" width="85%">
            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
        </td>
    </tr>
    <!-- Input IsHot -->
    <tr style="display: none;">
        <td class="SubHead"">
            <dnn:Label ID="lblIsHot" runat="server" ControlName="chkIsHot" Suffix=":" Visible="false">
            </dnn:Label>
        </td>
        <td colspan="2">
            <asp:CheckBox Text="Sản phẩm mới" ID="chkIsHot" runat="server" />
            <span style="display: none;">
                <asp:TextBox ID="txtHotPeriod" runat="server" Text="0"></asp:TextBox>
                <asp:Label ID="lblDays" runat="server" ResourceKey="lblDays.Text"></asp:Label>
            </span>
        </td>
    </tr>
    <!-- Input ChkCategories -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Thuộc mục </font></b>
        </td>
        <td colspan="2"  width="600px">
            <asp:CheckBoxList ID="chkCategoryList" runat="server" CssClass="Normal" RepeatColumns="2">
            </asp:CheckBoxList>
        </td>
    </tr>
    <!-- Input Smallimage -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ảnh toàn cảnh </font></b>
        </td>
        <td colspan="2">
            <input id="txtSmallimage" type="file" name="txtSmallimage" runat="server"  visible="false"/>
                        <dnn:URLControl ID="urlSmallImage" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
        </td>
        <td>
            <%--<img  id="imgSmallimage" runat="Server"/> ( Ảnh Cũ: <span id="imgSmallimage" runat="server"></span> )--%>
            <img id="imgSmallImage" runat="server" width="100"  />

            ( Ảnh Cũ: <span id="spSmallImage" runat="server"></span>)
        </td>
    </tr>
    <!-- Input Largeimage -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ảnh đặc tả </font></b>
        </td>
        <td>
            <input id="txtLargeimage" type="file" name="txtLargeimage" runat="server"  visible="false"/>
                        <dnn:URLControl ID="urlLargeImage" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
        </td>
        <td>
            <img id="imgLargeimage" runat="server" width="200" />
            ( Ảnh Cũ: <span id="spLargeimage" runat="server"></span>)
        </td>
    </tr>
    <!-- Input addimage1 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ảnh nghệ thuật </font></b>
        </td>
        <td>
            <input id="txtAddImage1" type="file" name="txtAddImage1" runat="server" visible="false" />
             <dnn:URLControl ID="urlSmallImageImgAdd1" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
        </td>
        <td>
            <img id="imgAdd1" runat="server" width="200" />
            ( Ảnh Cũ: <span id="spImgAdd1" runat="server"></span>)
        </td>
    </tr>
    <!-- Input addimage2 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ảnh cách trưng bày </font></b>
        </td>
        <td>
            <input id="txtAddImage2" type="file" name="txtAddImage2" runat="server" visible="false"/>
             <dnn:URLControl ID="urlSmallImageImgAdd2" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
        </td>
        <td>
            <img id="imgAdd2" runat="server" width="200" />
            ( Ảnh Cũ: <span id="spImgAdd2" runat="server"></span>)
        </td>
    </tr>
    <!-- Input addimage1 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ảnh khác </font></b>
        </td>
        <td>
            <input id="txtAddImage3" type="file" name="txtAddImage3" runat="server" visible="false"/>
              <dnn:URLControl ID="urlSmallImageImgAdd3" ShowFiles="true" ShowLog="False" ShowTrack="False"
                FileFilter="png,jpg,jpeg" ShowUrls="False" ShowTabs="False" Required="false" runat="server"
                ShowNone="false" ShowSecure="true" ShowUpLoad="False" ShowUsers="false" Width="300" />
        </td>
        <td>
            <img id="imgAdd3" runat="server" width="200" />
            ( Ảnh Cũ: <span id="spImgAdd3" runat="server"></span>)
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Thời tiết</font></b>
        </td>
        <td colspan="2">
            <select id="anh">
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/mua.png">mua.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/nang.png">nang.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/nhieumay.png">nhieumay.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/trongchau.png">trongchau.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/trongnha.png">trongnha.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/saubo.png">saubo.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/nhietdo.png">nhietdo.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/tuoinuoc.png">tuoinuoc.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/caygiong.png">caygiong.png</option>
                <option value="/DesktopModules/TH.NUCE.Ecommerce.Product.Mgmt/ImageThoiTiet/khac.png">khac.png</option>
            </select>
            <input id="ten" type="text" value="" />

            <input id="them" type="button" value="Thêm" />

            <br /><br />
            <div style="width:100%; float:left" id="tenfield_temp"></div>
            <br /><br />
            <input id="lamlai" type="button" value="Làm lại" />
            <br /><br />
            <asp:TextBox ID="txtaddInfo4" runat="server" Rows="5" Height="30px" Width="400px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input Lead -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Thông tin tóm tắt </font></b>
        </td>
        <td colspan="2"  width="900px">
            <%--<dnn:TextEditor ID="txtLead" runat="server" Mode="Rich" Width="100%" Height="400">
            </dnn:TextEditor>--%>
            <asp:TextBox ID="txtLead" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input Summary -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Chi tiết sản phẩm </font></b>
        </td>
        <td colspan="2" width="900px">
            <dnn:TextEditor ID="txtSummary" runat="server" Mode="Rich" Width="100%" Height="400">
            </dnn:TextEditor>
            <%--<asp:TextBox ID="txtSummary" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>--%>
        </td>
    </tr>
    <!-- Input addrichInfo1 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">AddrichInfo1 </font></b>
        </td>
        <td colspan="2" width="800px">
<%--            <dnn:TextEditor ID="txtaddRichInfo1" runat="server" Mode="Rich" Width="100%" Height="400">
            </dnn:TextEditor>--%>
            <asp:TextBox ID="txtaddRichInfo1" runat="server" Rows="5" Height="40px" Width="500px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input addrichInfo2 -->
    <tr style="width:100%; margin-bottom:15px; float:left;display: none;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Trang trí </font></b>
        </td>
        <td colspan="2" width="800px">
            <dnn:TextEditor ID="txtaddRichInfo2" runat="server" Mode="Rich" Width="100%" Height="400">
            </dnn:TextEditor>
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Trang trí </font></b>
        </td>
        <td colspan="2">

            <asp:TextBox ID="txtaddInfo5" runat="server" Rows="5" Height="40px" Width="500px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
            <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Chăm sóc </font></b>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtaddInfo6" runat="server" Rows="5" Height="40px" Width="500px" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    <!-- Input addrichInfo3 -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Hướng dẫn mua hàng </font></b>
        </td>
        <td colspan="2" width="900px">
            <dnn:TextEditor ID="txtaddRichInfo3" runat="server" Mode="Rich" Width="100%" Height="400">
            </dnn:TextEditor>
        </td>
    </tr>
    
    <!-- Input Weight -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Khối lượng </font></b>
        </td>
        <td colspan="2" width="600px">
            <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
            (Kg) 
        </td>
    </tr>
    <!-- Input Price -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Giá bán </font></b>
        </td>
        <td colspan="2" width="600px">
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            (VNĐ)
        </td>
    </tr>
    <!-- Input PriceOld -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Giá cũ </font></b>
        </td>
        <td colspan="2" width="600px">
            <asp:TextBox ID="txtPriceOld" runat="server"></asp:TextBox>
            (VNĐ)
        </td>
    </tr>
    <!-- Input StatusProduct -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Tình trạng sản phẩm </font></b>
        </td>
        <td colspan="2" width="600px">
            <asp:TextBox ID="txtStatusProduct" runat="server" Rows="5" Height="74px" Width="85%"
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    
    
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ngày cập nhật </font></b>
        </td>
        <td>
            <asp:TextBox ID="txtProducedDate" runat="server" Width="100px"></asp:TextBox>
            <asp:HyperLink ID="lnkProducedDate" runat="server">
                <asp:Image ID="imgProducedDate" runat="server" resourceKey="CalendarAlt.Text" />
            </asp:HyperLink>
        </td>
        <td align="left">
            <asp:Label ID="Label1" ForeColor="red" runat="server">(dd/mm/yyyy) (Không được bỏ trống)</asp:Label>
            &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ngày hết hạn </font></b>
        </td>
        <td>
            <asp:TextBox ID="txtExpiredDate" runat="server" Width="100px"></asp:TextBox>
            <asp:HyperLink ID="lnkExpiredDate" runat="server">
                <asp:Image ID="imgExpiredDate" runat="server" resourceKey="CalendarAlt.Text" />
            </asp:HyperLink>
        </td>
        <td align="left">
            <asp:Label ID="lblFormatterDateE" ForeColor="red" runat="server">(dd/mm/yyyy) (Không được bỏ trống)</asp:Label>
            &nbsp; &nbsp; &nbsp;
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Ngày hiển thị </font></b>
        </td>
        <td>
            <asp:TextBox ID="txtDisplayDate" runat="server" Width="100px"></asp:TextBox>
            <asp:HyperLink ID="lnkDisplayDate" runat="server">
                <asp:Image ID="imgDisplayDate" runat="server" resourceKey="CalendarAlt.Text" />
            </asp:HyperLink>
        </td>
        <td style="text-align: left;">
            <asp:Label ID="lblFormatterDateF" ForeColor="red" runat="server">(dd/mm/yyyy) (Không được bỏ trống)</asp:Label>
        </td>
    </tr>
    <!-- Input Order -->
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Thứ tự sản phẩm </font></b>
        </td>
        <td colspan="2" width="600px">
            <asp:TextBox ID="txtOrder" runat="server" Width="10%"></asp:TextBox>
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td colspan="3">
            <asp:PlaceHolder ID="phDynamic" runat="server"></asp:PlaceHolder>
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Tags sản phẩm </font></b>
            
        </td>
        <td colspan="2" width="600px">
            <asp:CheckBoxList ID="chkTags" runat="server" CssClass="Normal" RepeatColumns="5">
            </asp:CheckBoxList>
        </td>
    </tr>
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td class="SubHead">
            <b><font size="2" face="Arial">Link url </font></b>
        </td>
        <td colspan="2">
            <asp:TextBox ID="txtaddInfo3" runat="server" Rows="5" Height="74px" Width="85%" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
            
    <tr style="width:100%; margin-bottom:15px; float:left;">
        <td>
        </td>
        <td colspan="2">
            <asp:Button runat="server" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" />
            <asp:Button runat="server" Text="Rerturn" ID="btnReturn" OnClick="btnReturn_Click" />
        </td>
    </tr>
</table>
<asp:TextBox ID="txtProductNameOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtSmallimageOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtLargeimageOld" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtImageAdd1Old" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtImageAdd2Old" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtImageAdd3Old" runat="server" Visible="false"></asp:TextBox>
<asp:TextBox ID="txtCreatedDateOld" runat="server" Visible="false"></asp:TextBox>
<asp:PlaceHolder ID="phDynamicHide" runat="server"></asp:PlaceHolder>

<script type="text/javascript">
    $("#<%=txtaddInfo2.ClientID %>").keydown(function () {
        textCounter("<%=txtaddInfo2.ClientID %>", 'q17length', 160);
    });
    $("#<%=txtaddInfo2.ClientID %>").keyup(function () {
        textCounter("<%=txtaddInfo2.ClientID %>", 'q17length', 160);
    });

    $("#<%=txtaddInfo1.ClientID %>").keydown(function () {
        textCounter("<%=txtaddInfo1.ClientID %>", 'q17length0', 67);
    });
    $("#<%=txtaddInfo1.ClientID %>").keyup(function () {
        textCounter("<%=txtaddInfo1.ClientID %>", 'q17length0', 67);
    });
</script>
<script type="text/javascript">
    noidung = document.getElementById("<%=txtaddInfo4.ClientID %>").innerHTML;
    noidung_tam = document.getElementById("<%=txtaddInfo4.ClientID %>").innerHTML;
    //alert(noidung);
    i = 0;
    start = document.getElementById("<%=txtaddInfo4.ClientID %>").innerHTML;
    var decoded = $('<div/>').html(start).text();
    //alert(start);
    $("#tenfield_temp").html(decoded);
    $("#them").click(function () {
        i++;
        ten = document.getElementById("ten").value.trim();
        anh = document.getElementById("anh").value.trim();
        noidung_tam = noidung_tam + "<img onclick='reply_click(this.id)' id='" + i + "' title='" + ten + "' title='" + ten + "' src='" + anh + "'>";
        noidung = noidung + "<img onclick='reply_click(this.id)' id='" + i + "' title='" + ten + "' title='" + ten + "' src='" + anh + "'>";
        $("#tenfield_temp").html(noidung_tam);
        $("#<%=txtaddInfo4.ClientID %>").html(noidung);
        document.getElementById("ten").value = "";
        //alert(start);
    });
    $("#lamlai").click(function () {
        noidung = "";
        noidung_tam = "";
        $("#tenfield_temp").html("");
        $("#<%=txtaddInfo4.ClientID %>").html("");

    });
    function reply_click(id) {
        ten2 = document.getElementById(id).title;
        if (ten2 == "") ten2 = "Không có chú thích";
        alert(ten2);
    }

</script>
