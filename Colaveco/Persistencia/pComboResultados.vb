Public Class pComboResultados
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComboResultados = CType(o, dComboResultados)
        Dim sql As String = "INSERT INTO comboresultados (id, analisis, texto) VALUES (" & obj.ID & ", " & obj.ANALISIS & ", '" & obj.TEXTO & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comboresultados', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComboResultados = CType(o, dComboResultados)
        Dim sql As String = "UPDATE comboresultados SET analisis = " & obj.ANALISIS & ", texto = '" & obj.TEXTO & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comboresultados', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dComboResultados = CType(o, dComboResultados)
        Dim sql As String = "DELETE FROM comboresultados WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'comboresultados', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dComboResultados
        Dim obj As dComboResultados = CType(o, dComboResultados)
        Dim l As New dComboResultados
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, texto FROM comboresultados WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Long)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.TEXTO = CType(unaFila.Item(2), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, analisis, texto FROM comboresultados"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComboResultados
                    l.ID = CType(unaFila.Item(0), Long)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.TEXTO = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxanalisis(ByVal idanalisis As Integer) As ArrayList
        Dim sql As String = "SELECT id, analisis, texto FROM comboresultados WHERE analisis = " & idanalisis & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dComboResultados
                    l.ID = CType(unaFila.Item(0), Long)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.TEXTO = CType(unaFila.Item(2), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
