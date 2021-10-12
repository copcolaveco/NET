Public Class pMetodos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMetodos = CType(o, dMetodos)
        Dim sql As String = "INSERT INTO metodosyestandares (id, area, analisis, metodo, aplicacion, estandar, temptiempo, modificaciones) VALUES (" & obj.ID & ", '" & obj.AREA & "', '" & obj.ANALISIS & "', '" & obj.METODO & "', '" & obj.APLICACION & "', '" & obj.ESTANDAR & "', '" & obj.TEMPTIEMPO & "', '" & obj.MODIFICACIONES & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'metodos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMetodos = CType(o, dMetodos)
        Dim sql As String = "UPDATE metodosyestandares SET area = '" & obj.AREA & "',analisis = '" & obj.ANALISIS & "',metodo = '" & obj.METODO & "',aplicacion = '" & obj.APLICACION & "',estandar = '" & obj.ESTANDAR & "',temptiempo = '" & obj.TEMPTIEMPO & "',modificaciones = '" & obj.MODIFICACIONES & "' WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'metodos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMetodos = CType(o, dMetodos)
        Dim sql As String = "DELETE FROM metodosyestandares WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'metodos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMetodos
        Dim obj As dMetodos = CType(o, dMetodos)
        Dim l As New dMetodos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, area, analisis, metodo, aplicacion, estandar, temptiempo, modificaciones FROM metodosyestandares WHERE id = " & obj.ID)

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.AREA = CType(unaFila.Item(1), String)
                l.ANALISIS = CType(unaFila.Item(2), String)
                l.METODO = CType(unaFila.Item(3), String)
                l.APLICACION = CType(unaFila.Item(4), String)
                l.ESTANDAR = CType(unaFila.Item(5), String)
                l.TEMPTIEMPO = CType(unaFila.Item(6), String)
                l.MODIFICACIONES = CType(unaFila.Item(7), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, area, analisis, metodo, aplicacion, estandar, temptiempo, modificaciones FROM metodosyestandares"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMetodos
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.AREA = CType(unaFila.Item(1), String)
                    l.ANALISIS = CType(unaFila.Item(2), String)
                    l.METODO = CType(unaFila.Item(3), String)
                    l.APLICACION = CType(unaFila.Item(4), String)
                    l.ESTANDAR = CType(unaFila.Item(5), String)
                    l.TEMPTIEMPO = CType(unaFila.Item(6), String)
                    l.MODIFICACIONES = CType(unaFila.Item(7), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarporid(ByVal texto As String) As ArrayList
        Dim sql As String = ("SELECT id, area, analisis, metodo, aplicacion, estandar, temptiempo, modificaciones FROM metodosyestandares where analisis = '" & texto & "'")
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dMetodos
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.AREA = CType(unaFila.Item(1), String)
                    l.ANALISIS = CType(unaFila.Item(2), String)
                    l.METODO = CType(unaFila.Item(3), String)
                    l.APLICACION = CType(unaFila.Item(4), String)
                    l.ESTANDAR = CType(unaFila.Item(5), String)
                    l.TEMPTIEMPO = CType(unaFila.Item(6), String)
                    l.MODIFICACIONES = CType(unaFila.Item(7), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
End Class
