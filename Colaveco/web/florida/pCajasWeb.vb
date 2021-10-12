Public Class pCajasWeb
    Inherits Conectoras.ConexionMySQL_Florida
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "INSERT INTO cajas (id, codigo, estado, cliente, modcolaveco, modflorida) VALUES (" & obj.ID & ", '" & obj.CODIGO & "'," & obj.ESTADO & "," & obj.CLIENTE & "," & obj.MODCOLAVECO & "," & obj.MODFLORIDA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET id = " & obj.ID & ",  estado= " & obj.ESTADO & ", cliente = " & obj.CLIENTE & ", modcolaveco = " & obj.MODCOLAVECO & ", modflorida = " & obj.MODFLORIDA & "  WHERE codigo='" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'cajas', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcaja(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= " & obj.ESTADO & ", cliente = " & obj.CLIENTE & ", modcolaveco = " & obj.MODCOLAVECO & ", modflorida = " & obj.MODFLORIDA & "  WHERE codigo='" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarlaboratorio(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 1, cliente =-1, modcolaveco=1, modflorida=0  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarcliente(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 2  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarflorida(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 3, cliente=-1, modcolaveco=1, modflorida=0  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarCardal(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 4, cliente= -1, modcolaveco=1, modflorida=0  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcarCanelones(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 5, cliente= -1, modcolaveco=1, modflorida=0  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function marcardesaparecida(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "UPDATE cajas SET estado= 4  WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim sql As String = "DELETE FROM cajas WHERE codigo = '" & obj.CODIGO & "'"

        Dim lista As New ArrayList
        lista.Add(sql)


        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dCajasWeb
        Dim obj As dCajasWeb = CType(o, dCajasWeb)
        Dim c As New dCajasWeb
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas WHERE codigo = '" & obj.CODIGO & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                c.ID = CType(unaFila.Item(0), Long)
                c.CODIGO = CType(unaFila.Item(1), String)
                c.ESTADO = CType(unaFila.Item(2), Integer)
                c.CLIENTE = CType(unaFila.Item(3), Long)
                c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                Return c
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarPorCodigo(ByVal codigo As String) As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas WHERE codigo LIKE '%" & codigo & "%' ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas ORDER BY estado, codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar2() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenLaboratorio() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas WHERE estado = 1 ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenClientes() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas WHERE estado = 2 ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarenFlorida() As ArrayList
        Dim sql As String = "SELECT id, codigo, estado, cliente, modcolaveco, modflorida FROM cajas WHERE estado = 3 ORDER BY codigo asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim c As New dCajasWeb
                    c.ID = CType(unaFila.Item(0), Long)
                    c.CODIGO = CType(unaFila.Item(1), String)
                    c.ESTADO = CType(unaFila.Item(2), Integer)
                    c.CLIENTE = CType(unaFila.Item(3), Long)
                    c.MODCOLAVECO = CType(unaFila.Item(4), Integer)
                    c.MODFLORIDA = CType(unaFila.Item(5), Integer)
                    Lista.Add(c)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
