Public Class pTecnicoMuestreo

    Inherits Conectoras.ConexionMySQL

    Public Function guardar(ByVal o As Object) As Boolean
        Dim obj As dTecnicoMuestreo = CType(o, dTecnicoMuestreo)
        Dim sql As String = "INSERT INTO tecnico_muestreo (tecnico_muestreo_id, nombre, apellido, estatus) VALUES (" & obj.TECNICO_MUESTREO_ID & ", '" & obj.NOMBRE & "', '" & obj.APELLIDO & "','" & obj.ESTATUS & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function modificar(ByVal o As Object) As Boolean
        Dim obj As dTecnicoMuestreo = CType(o, dTecnicoMuestreo)
        Dim sql As String = "UPDATE tecnico_muestreo SET nombre= '" & o.NOMBRE & "', apellido= '" & o.APELLIDO & "', estatus = '" & o.ESTATUS & "' WHERE tecnico_muestreo_id = '" & o.TECNICO_MUESTREO_ID & "' "

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object) As Boolean
        Dim obj As dTecnicoMuestreo = CType(o, dTecnicoMuestreo)
        Dim sql As String = "UPDATE tecnico_muestreo SET estatus = 1 WHERE tecnico_muestreo_id = " & obj.TECNICO_MUESTREO_ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function buscarById(ByVal o As Object) As dTecnicoMuestreo
        Dim obj As dTecnicoMuestreo = CType(o, dTecnicoMuestreo)
        Dim p As New dTecnicoMuestreo
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT tecnico_muestreo_id, nombre, apellido, estatus FROM tecnico_muestreo WHERE tecnico_muestreo_id = " & obj.TECNICO_MUESTREO_ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.TECNICO_MUESTREO_ID = CType(unaFila.Item(0), Long)
                p.NOMBRE = CType(unaFila.Item(1), String)
                p.APELLIDO = CType(unaFila.Item(2), String)
                p.ESTATUS = CType(unaFila.Item(3), Integer)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarTodos() As ArrayList
        Dim sql As String = "SELECT tecnico_muestreo_id, nombre, apellido, estatus FROM tecnico_muestreo where estatus = 2 order by tecnico_muestreo_id asc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dTecnicoMuestreo
                    p.TECNICO_MUESTREO_ID = CType(unaFila.Item(0), Long)
                    p.NOMBRE = CType(unaFila.Item(1), String)
                    p.APELLIDO = CType(unaFila.Item(2), String)
                    p.ESTATUS = CType(unaFila.Item(3), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Class
