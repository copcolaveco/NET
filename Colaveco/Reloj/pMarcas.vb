Public Class pMarcas
    Inherits Conectoras.ConexionMySQL_reloj
    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dMarcas = CType(o, dMarcas)
        Dim sql As String = "INSERT INTO marcas (id, usuario, marca, tipomarca) VALUES (" & obj.ID & ", " & obj.USUARIO & ", '" & obj.MARCA & "', " & obj.TIPOMARCA & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

       
        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dMarcas = CType(o, dMarcas)
        Dim sql As String = "UPDATE marcas SET usuario = " & obj.USUARIO & ", marca = '" & obj.MARCA & "', tipomarca= " & obj.TIPOMARCA & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dMarcas = CType(o, dMarcas)
        Dim sql As String = "DELETE FROM marcas WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

       

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMarcas
        Dim obj As dMarcas = CType(o, dMarcas)
        Dim l As New dMarcas
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, usuario, marca, tipomarca FROM marcas WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.USUARIO = CType(unaFila.Item(1), Integer)
                l.MARCA = CType(unaFila.Item(2), String)
                l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
  
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, usuario, marca, tipomarca FROM marcas"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.USUARIO = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(2), String)
                    l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT DISTINCT DATE (marca) FROM marcas WHERE usuario = " & usu & " AND DATE(marca) >= '" & desde & "' AND DATE (marca) <= '" & hasta & "' ORDER BY marca ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    'l.ID = CType(unaFila.Item(0), Long)
                    'l.USUARIORELOJ = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(0), String)
                    'l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario2(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, usuario, marca, tipomarca FROM marcas WHERE usuario = " & usu & " AND marca BETWEEN '" & desde & "' AND '" & hasta & "' ORDER BY marca ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.USUARIO = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(2), String)
                    l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxusuario_bd(ByVal usu As Integer, ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, usuario, marca, tipomarca FROM marcas WHERE usuario = " & usu & " AND DATE(marca) >= '" & desde & "' AND DATE (marca) <= '" & hasta & "' ORDER BY marca ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.USUARIO = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(2), String)
                    l.TIPOMARCA = CType(unaFila.Item(3), Integer)

                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultima(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, usuario, marca, tipomarca FROM marcas WHERE usuario = " & idusuario & " order by marca desc LIMIT 1"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.USUARIO = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(2), String)
                    l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarultimas200(ByVal idusuario As Integer) As ArrayList
        Dim sql As String = "SELECT id, usuario, marca, tipomarca FROM marcas WHERE usuario = " & idusuario & " ORDER BY marca DESC LIMIT 200"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMarcas
                    l.ID = CType(unaFila.Item(0), Long)
                    l.USUARIO = CType(unaFila.Item(1), Integer)
                    l.MARCA = CType(unaFila.Item(2), String)
                    l.TIPOMARCA = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
