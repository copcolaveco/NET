Public Class pListaMetodos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim sql As String = "INSERT INTO listademetodos (id, analisis, metodo, pordefecto) VALUES (" & obj.ID & ", " & obj.ANALISIS & ", '" & obj.METODO & "', " & obj.PORDEFECTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listademetodos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim sql As String = "UPDATE listademetodos SET analisis = " & obj.ANALISIS & ", metodo = '" & obj.METODO & "', pordefecto = " & obj.PORDEFECTO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listademetodos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarxdefecto(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim sql As String = "UPDATE listademetodos SET pordefecto = 0  WHERE analisis = " & obj.ANALISIS & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listademetodos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim sql As String = "DELETE FROM listademetodos WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'listademetodos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dListaMetodos
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim l As New dListaMetodos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, metodo, pordefecto FROM listademetodos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.METODO = CType(unaFila.Item(2), String)
                l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxanalisis(ByVal o As Object) As dListaMetodos
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim l As New dListaMetodos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, metodo, pordefecto FROM listademetodos WHERE analisis = " & obj.ANALISIS & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.METODO = CType(unaFila.Item(2), String)
                l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxanalisisymetodo(ByVal o As Object) As dListaMetodos
        Dim obj As dListaMetodos = CType(o, dListaMetodos)
        Dim l As New dListaMetodos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, metodo, pordefecto FROM listademetodos WHERE analisis = " & obj.ANALISIS & " and id = " & obj.METODO & " ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.METODO = CType(unaFila.Item(2), String)
                l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, analisis, metodo, pordefecto FROM listademetodos"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaMetodos
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.METODO = CType(unaFila.Item(2), String)
                    l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanalisis(ByVal idanalisis As Integer) As ArrayList
        Dim sql As String = "SELECT id, analisis, metodo, pordefecto FROM listademetodos WHERE analisis = " & idanalisis & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dListaMetodos
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.METODO = CType(unaFila.Item(2), String)
                    l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
