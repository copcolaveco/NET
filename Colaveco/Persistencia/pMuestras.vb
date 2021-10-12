Public Class pMuestras
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestras = CType(o, dMuestras)
        Dim sql As String = "INSERT INTO muestra (id, nombre, tipoinforme, nousar, acreditado) VALUES (" & obj.ID & ", '" & obj.NOMBRE & "', " & obj.TIPOINFORME & ", " & obj.NOUSAR & ", " & obj.ACREDITADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestra', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestras = CType(o, dMuestras)
        Dim sql As String = "UPDATE muestra SET nombre = '" & obj.NOMBRE & "', tipoinforme= " & obj.TIPOINFORME & ", nousar= " & obj.NOUSAR & ", acreditado= " & obj.ACREDITADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestra', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dMuestras = CType(o, dMuestras)
        Dim sql As String = "DELETE FROM muestra WHERE id = " & obj.ID

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'muestra', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dMuestras
        Dim obj As dMuestras = CType(o, dMuestras)
        Dim m As New dMuestras
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, nombre, tipoinforme, nousar, acreditado FROM muestra WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                m.ID = CType(unaFila.Item(0), Integer)
                m.NOMBRE = CType(unaFila.Item(1), String)
                m.TIPOINFORME = CType(unaFila.Item(2), Integer)
                m.NOUSAR = CType(unaFila.Item(3), Integer)
                m.ACREDITADO = CType(unaFila.Item(4), Integer)
                Return m
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, nombre, tipoinforme, nousar, acreditado FROM muestra ORDER BY tipoinforme ASC, nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMuestras
                    m.ID = CType(unaFila.Item(0), Integer)
                    m.NOMBRE = CType(unaFila.Item(1), String)
                    m.TIPOINFORME = CType(unaFila.Item(2), Integer)
                    m.NOUSAR = CType(unaFila.Item(3), Integer)
                    m.ACREDITADO = CType(unaFila.Item(4), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxinforme(ByVal informe As Integer) As ArrayList
        Dim sql As String = "SELECT id, nombre, tipoinforme, nousar, acreditado FROM muestra WHERE tipoinforme = " & informe & " and nousar = 0 ORDER BY nombre ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim m As New dMuestras
                    m.ID = CType(unaFila.Item(0), Integer)
                    m.NOMBRE = CType(unaFila.Item(1), String)
                    m.TIPOINFORME = CType(unaFila.Item(2), Integer)
                    m.NOUSAR = CType(unaFila.Item(3), Integer)
                    m.ACREDITADO = CType(unaFila.Item(4), Integer)
                    Lista.Add(m)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
