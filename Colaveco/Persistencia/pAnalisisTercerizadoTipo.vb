Public Class pAnalisisTercerizadoTipo
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizadoTipo = CType(o, dAnalisisTercerizadoTipo)
        Dim sql As String = "INSERT INTO analisistercerizado_tipo (id, tipoinforme, nombre, metodo, unidad, depende, orden) VALUES (" & obj.ID & ", " & obj.IDTIPOINFORME & ",'" & obj.NOMBRE & "','" & obj.METODO & "','" & obj.UNIDAD & "'," & obj.DEPENDE & "," & obj.ORDEN & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado_tipo', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizadoTipo = CType(o, dAnalisisTercerizadoTipo)
        Dim sql As String = "UPDATE analisistercerizado_tipo SET tipoinforme=" & obj.IDTIPOINFORME & ", nombre = '" & obj.NOMBRE & "', metodo = '" & obj.METODO & "', unidad = '" & obj.UNIDAD & "', depende = " & obj.DEPENDE & ", orden = " & obj.ORDEN & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado_tipo', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisTercerizadoTipo = CType(o, dAnalisisTercerizadoTipo)
        Dim sql As String = "DELETE FROM analisistercerizado_tipo WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisistercerizado_tipo', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAnalisisTercerizadoTipo
        Dim obj As dAnalisisTercerizadoTipo = CType(o, dAnalisisTercerizadoTipo)
        Dim s As New dAnalisisTercerizadoTipo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, tipoinforme, nombre, ifnull(metodo,''), ifnull(unidad,''), depende, orden  FROM analisistercerizado_tipo WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Integer)
                s.IDTIPOINFORME = CType(unaFila.Item(1), Integer)
                s.NOMBRE = CType(unaFila.Item(2), String)
                s.METODO = CType(unaFila.Item(3), String)
                s.UNIDAD = CType(unaFila.Item(4), String)
                s.DEPENDE = CType(unaFila.Item(5), Integer)
                s.ORDEN = CType(unaFila.Item(6), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, tipoinforme, nombre, ifnull(metodo,''), ifnull(unidad,''), depende, orden FROM analisistercerizado_tipo ORDER BY tipoinforme ASC, nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dAnalisisTercerizadoTipo
                    s.ID = CType(unaFila.Item(0), Integer)
                    s.IDTIPOINFORME = CType(unaFila.Item(1), Integer)
                    s.NOMBRE = CType(unaFila.Item(2), String)
                    s.METODO = CType(unaFila.Item(3), String)
                    s.UNIDAD = CType(unaFila.Item(4), String)
                    s.DEPENDE = CType(unaFila.Item(5), Integer)
                    s.ORDEN = CType(unaFila.Item(6), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarportipoinforme(ByVal texto As Integer) As ArrayList
        Dim sql As String = ("SELECT id, tipoinforme, nombre, ifnull(metodo,''), ifnull(unidad,''), depende, orden FROM analisistercerizado_tipo where tipoinforme = " & texto & " AND depende = 0 order by nombre asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dAnalisisTercerizadoTipo
                    s.ID = CType(unaFila.Item(0), Integer)
                    s.IDTIPOINFORME = CType(unaFila.Item(1), Integer)
                    s.NOMBRE = CType(unaFila.Item(2), String)
                    s.METODO = CType(unaFila.Item(3), String)
                    s.UNIDAD = CType(unaFila.Item(4), String)
                    s.DEPENDE = CType(unaFila.Item(5), Integer)
                    s.ORDEN = CType(unaFila.Item(6), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardependientes(ByVal id As Integer) As ArrayList
        Dim sql As String = ("SELECT id, tipoinforme, nombre, ifnull(metodo,''), ifnull(unidad,''), depende, orden FROM analisistercerizado_tipo where depende = " & id & " order by nombre asc")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dAnalisisTercerizadoTipo
                    s.ID = CType(unaFila.Item(0), Integer)
                    s.IDTIPOINFORME = CType(unaFila.Item(1), Integer)
                    s.NOMBRE = CType(unaFila.Item(2), String)
                    s.METODO = CType(unaFila.Item(3), String)
                    s.UNIDAD = CType(unaFila.Item(4), String)
                    s.DEPENDE = CType(unaFila.Item(5), Integer)
                    s.ORDEN = CType(unaFila.Item(6), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
