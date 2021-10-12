Public Class pAnalisisUnidad
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisUnidad = CType(o, dAnalisisUnidad)
        Dim sql As String = "INSERT INTO analisis_unidad (id, analisis, unidad, pordefecto) VALUES (" & obj.ID & ", " & obj.ANALISIS & ", '" & obj.UNIDAD & "', " & obj.PORDEFECTO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisis_unidad', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisUnidad = CType(o, dAnalisisUnidad)
        Dim sql As String = "UPDATE analisis_unidad SET analisis = " & obj.ANALISIS & ", unidad = '" & obj.UNIDAD & "', pordefecto = " & obj.PORDEFECTO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisis_unidad', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function desmarcarxdefecto(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisUnidad = CType(o, dAnalisisUnidad)
        Dim sql As String = "UPDATE analisis_unidad SET pordefecto = 0  WHERE analisis = " & obj.ANALISIS & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisis_unidad', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dAnalisisUnidad = CType(o, dAnalisisUnidad)
        Dim sql As String = "DELETE FROM analisis_unidad WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'analisis_unidad', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dAnalisisUnidad
        Dim obj As dAnalisisUnidad = CType(o, dAnalisisUnidad)
        Dim l As New dAnalisisUnidad
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, analisis, unidad, pordefecto FROM analisis_unidad WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.ID = CType(unaFila.Item(0), Integer)
                l.ANALISIS = CType(unaFila.Item(1), Integer)
                l.UNIDAD = CType(unaFila.Item(2), String)
                l.PORDEFECTO = CType(unaFila.Item(3), Integer)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, analisis, unidad, pordefecto FROM analisis_unidad"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisUnidad
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.UNIDAD = CType(unaFila.Item(2), String)
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
        Dim sql As String = "SELECT id, analisis, unidad, pordefecto FROM analisis_unidad WHERE analisis = " & idanalisis & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dAnalisisUnidad
                    l.ID = CType(unaFila.Item(0), Integer)
                    l.ANALISIS = CType(unaFila.Item(1), Integer)
                    l.UNIDAD = CType(unaFila.Item(2), String)
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
