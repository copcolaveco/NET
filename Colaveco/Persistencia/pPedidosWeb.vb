Public Class pPedidosWeb
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim sql As String = "INSERT INTO pedidosweb (id, fecha, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones, realizado, cancelado) VALUES (" & obj.ID & ",'" & obj.FECHA & "'," & obj.CODIGO & ",'" & obj.NOMBRE & "','" & obj.DIRECCION & "'," & obj.AGENCIA & ",'" & obj.TELEFONO & "','" & obj.EMAIL & "'," & obj.CCONSERVANTE & "," & obj.SCONSERVANTE & "," & obj.AGUA & "," & obj.SANGRE & ",'" & obj.OBSERVACIONES & "'," & obj.REALIZADO & "," & obj.CANCELADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim sql As String = "UPDATE pedidosweb SET fecha = '" & obj.FECHA & "', codigo = " & obj.CODIGO & ",nombre='" & obj.NOMBRE & "',direccion='" & obj.DIRECCION & "',agencia=" & obj.AGENCIA & ",telefono='" & obj.TELEFONO & "',email='" & obj.EMAIL & "',cconservante=" & obj.CCONSERVANTE & ",sconservante=" & obj.SCONSERVANTE & ",agua=" & obj.AGUA & ",sangre=" & obj.SANGRE & ",observaciones='" & obj.OBSERVACIONES & "',realizado=" & obj.REALIZADO & ",cancelado=" & obj.CANCELADO & "   WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarrealizado(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim sql As String = "UPDATE pedidosweb SET realizado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcancelado(ByVal o As Object) As Boolean
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim sql As String = "UPDATE pedidosweb SET cancelado= 1 WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim sql As String = "DELETE FROM pedidosweb WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dPedidosWeb
        Dim obj As dPedidosWeb = CType(o, dPedidosWeb)
        Dim c As New dPedidosWeb
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones, realizado, cancelado FROM pedidosweb WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.FECHA = CType(unaFila.Item(1), String)
                c.CODIGO = CType(unaFila.Item(2), Long)
                c.NOMBRE = CType(unaFila.Item(3), String)
                c.DIRECCION = CType(unaFila.Item(4), String)
                c.AGENCIA = CType(unaFila.Item(5), Integer)
                c.TELEFONO = CType(unaFila.Item(6), String)
                c.EMAIL = CType(unaFila.Item(7), String)
                c.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                c.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                c.AGUA = CType(unaFila.Item(10), Integer)
                c.SANGRE = CType(unaFila.Item(11), Integer)
                c.OBSERVACIONES = CType(unaFila.Item(12), String)
                c.REALIZADO = CType(unaFila.Item(13), Integer)
                c.CANCELADO = CType(unaFila.Item(14), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, codigo, nombre, direccion, agencia, telefono, email, cconservante, sconservante, agua, sangre, observaciones, realizado, cancelado FROM pedidosweb WHERE realizado = 0 And cancelado = 0 order by id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dPedidosWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.FECHA = CType(unaFila.Item(1), String)
                    c.CODIGO = CType(unaFila.Item(2), Long)
                    c.NOMBRE = CType(unaFila.Item(3), String)
                    c.DIRECCION = CType(unaFila.Item(4), String)
                    c.AGENCIA = CType(unaFila.Item(5), Integer)
                    c.TELEFONO = CType(unaFila.Item(6), String)
                    c.EMAIL = CType(unaFila.Item(7), String)
                    c.CCONSERVANTE = CType(unaFila.Item(8), Integer)
                    c.SCONSERVANTE = CType(unaFila.Item(9), Integer)
                    c.AGUA = CType(unaFila.Item(10), Integer)
                    c.SANGRE = CType(unaFila.Item(11), Integer)
                    c.OBSERVACIONES = CType(unaFila.Item(12), String)
                    c.REALIZADO = CType(unaFila.Item(13), Integer)
                    c.CANCELADO = CType(unaFila.Item(14), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
