Public Class pPedidosWeb_com
    Inherits Conectoras.ConexionMySQL_comuy
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb_com = CType(o, dPedidosWeb_com)
        Dim sql As String = "INSERT INTO pedidofrascosweb (id, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones) VALUES (" & obj.ID & "," & obj.CODIGO & ",'" & obj.NOMBRE & "','" & obj.DIRECCION & "'," & obj.AGENCIA & ",'" & obj.TELEFONO & "','" & obj.EMAIL & "'," & obj.CCONSERVANTE & "," & obj.SCONSERVANTE & "," & obj.AGUA & "," & obj.SANGRE & ",'" & obj.OBSERVACIONES & "' )"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb_com = CType(o, dPedidosWeb_com)
        Dim sql As String = "UPDATE pedidofrascosweb SET codigo = " & obj.CODIGO & ",nombre='" & obj.NOMBRE & "',direccion='" & obj.DIRECCION & "',agencia=" & obj.AGENCIA & ",telefono='" & obj.TELEFONO & "',email='" & obj.EMAIL & "',cconservante=" & obj.CCONSERVANTE & ",sconservante=" & obj.SCONSERVANTE & ",agua=" & obj.AGUA & ",sangre=" & obj.SANGRE & ",observaciones='" & obj.OBSERVACIONES & "'   WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb_com = CType(o, dPedidosWeb_com)
        Dim sql As String = "DELETE FROM pedidofrascosweb WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidosWeb_com
        Dim obj As dPedidosWeb_com = CType(o, dPedidosWeb_com)
        Dim c As New dPedidosWeb_com
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones FROM pedidofrascosweb WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.CODIGO = CType(unaFila.Item(1), Long)
                c.NOMBRE = CType(unaFila.Item(2), String)
                c.DIRECCION = CType(unaFila.Item(3), String)
                c.AGENCIA = CType(unaFila.Item(4), Integer)
                c.TELEFONO = CType(unaFila.Item(5), String)
                c.EMAIL = CType(unaFila.Item(6), String)
                c.CCONSERVANTE = CType(unaFila.Item(7), Integer)
                c.SCONSERVANTE = CType(unaFila.Item(8), Integer)
                c.AGUA = CType(unaFila.Item(9), Integer)
                c.SANGRE = CType(unaFila.Item(10), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(11), String)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones FROM pedidofrascosweb order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPedidosWeb_com
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), Long)
                    c.NOMBRE = CType(unaFila.Item(2), String)
                    c.DIRECCION = CType(unaFila.Item(3), String)
                    c.AGENCIA = CType(unaFila.Item(4), Integer)
                    c.TELEFONO = CType(unaFila.Item(5), String)
                    c.EMAIL = CType(unaFila.Item(6), String)
                    c.CCONSERVANTE = CType(unaFila.Item(7), Integer)
                    c.SCONSERVANTE = CType(unaFila.Item(8), Integer)
                    c.AGUA = CType(unaFila.Item(9), Integer)
                    c.SANGRE = CType(unaFila.Item(10), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(11), String)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
