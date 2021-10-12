Public Class pAcreditacion
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAcreditacion = CType(o, dAcreditacion)
        Dim sql As String = "INSERT INTO acreditacion (analisis, descripcion, desde, hasta) VALUES (" & obj.ANALISIS & ", '" & obj.DESCRIPCION & "', '" & obj.DESDE & "', '" & obj.HASTA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'acreditacion', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAcreditacion = CType(o, dAcreditacion)
        Dim sql As String = "UPDATE acreditacion SET descripcion = '" & obj.DESCRIPCION & "', desde = '" & obj.DESDE & "', hasta = '" & obj.HASTA & "' WHERE analisis = " & obj.ANALISIS & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'acreditacion', 'modificación', " & obj.ANALISIS & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
   
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAcreditacion = CType(o, dAcreditacion)
        Dim sql As String = "DELETE FROM acreditacion WHERE analisis = " & obj.ANALISIS & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'acreditacion', 'eliminación', " & obj.ANALISIS & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAcreditacion
        Dim obj As dAcreditacion = CType(o, dAcreditacion)
        Dim l As New dAcreditacion
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT analisis, ifnull(descripcion,''), ifnull(desde,''), ifnull(hasta,'') FROM acreditacion WHERE analisis = " & obj.ANALISIS & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ANALISIS = CType(unaFila.Item(0), Integer)
                l.DESCRIPCION = CType(unaFila.Item(1), String)
                l.DESDE = CType(unaFila.Item(2), String)
                l.HASTA = CType(unaFila.Item(3), String)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT analisis, ifnull(descripcion,''), ifnull(desde,''), ifnull(hasta,'') FROM acreditacion"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAcreditacion
                    l.ANALISIS = CType(unaFila.Item(0), Integer)
                    l.DESCRIPCION = CType(unaFila.Item(1), String)
                    l.DESDE = CType(unaFila.Item(2), String)
                    l.HASTA = CType(unaFila.Item(3), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
   
End Class
