Public Class pControlGrasaProteina
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlGrasaProteina = CType(o, dControlGrasaProteina)
        Dim sql As String = "INSERT INTO control_grasa_proteina (id, fecha, bentley_g, delta_g, rosegottlieb_g, gerber_g, bentley_p, delta_p, dumas_p, kjeldah_p, operador) VALUES (" & obj.ID & ", '" & obj.FECHA & "', " & obj.BENTLEYG & ",  " & obj.DELTAG & "," & obj.ROSEGOTTLIEBG & ", " & obj.GERBERG & ", " & obj.BENTLEYP & ", " & obj.DELTAP & "," & obj.DUMASP & ",  " & obj.KJELDAHP & ",  " & obj.OPERADOR & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controlgrasaproteina', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlGrasaProteina = CType(o, dControlGrasaProteina)
        Dim sql As String = "UPDATE control_grasa_proteina SET fecha ='" & obj.FECHA & "', bentley_g=" & obj.BENTLEYG & ",delta_g=" & obj.DELTAG & ",rosegottlieb_g=" & obj.ROSEGOTTLIEBG & ", gerber_g=" & obj.GERBERG & ", bentley_p=" & obj.BENTLEYP & ", delta_p=" & obj.DELTAP & ",dumas_p=" & obj.DUMASP & ", kjeldah_p=" & obj.KJELDAHP & ", operador =" & obj.OPERADOR & " WHERE ID = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controlgrasaproteina', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dControlGrasaProteina = CType(o, dControlGrasaProteina)
        Dim sql As String = "DELETE FROM control_grasa_proteina WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'controlgrasaproteina', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dControlGrasaProteina
        Dim obj As dControlGrasaProteina = CType(o, dControlGrasaProteina)
        Dim s As New dControlGrasaProteina
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, fecha, bentley_g, delta_g, rosegottlieb_g, gerber_g, bentley_p, delta_p, dumas_p, kjeldah_p, operador FROM control_grasa_proteina WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                s.ID = CType(unaFila.Item(0), Long)
                s.FECHA = CType(unaFila.Item(1), String)
                s.BENTLEYG = CType(unaFila.Item(2), Double)
                s.DELTAG = CType(unaFila.Item(3), Double)
                s.ROSEGOTTLIEBG = CType(unaFila.Item(4), Double)
                s.GERBERG = CType(unaFila.Item(5), Double)
                s.BENTLEYP = CType(unaFila.Item(6), Double)
                s.DELTAP = CType(unaFila.Item(7), Double)
                s.DUMASP = CType(unaFila.Item(8), Double)
                s.KJELDAHP = CType(unaFila.Item(9), Double)
                s.OPERADOR = CType(unaFila.Item(10), Integer)
                Return s
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, fecha, bentley_g, delta_g, rosegottlieb_g, gerber_g, bentley_p, delta_p, dumas_p, kjeldah_p, operador FROM control_grasa_proteina order by fecha desc, id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dControlGrasaProteina
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.BENTLEYG = CType(unaFila.Item(2), Double)
                    s.DELTAG = CType(unaFila.Item(3), Double)
                    s.ROSEGOTTLIEBG = CType(unaFila.Item(4), Double)
                    s.GERBERG = CType(unaFila.Item(5), Double)
                    s.BENTLEYP = CType(unaFila.Item(6), Double)
                    s.DELTAP = CType(unaFila.Item(7), Double)
                    s.DUMASP = CType(unaFila.Item(8), Double)
                    s.KJELDAHP = CType(unaFila.Item(9), Double)
                    s.OPERADOR = CType(unaFila.Item(10), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporid(ByVal texto As Long) As ArrayList
        Dim sql As String = ("SELECT id, fecha, bentley_g, delta_g, rosegottlieb_g, gerber_g, bentley_p, delta_p, dumas_p, kjeldah_p, operador FROM control_grasa_proteina where id = " & texto & "")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dControlGrasaProteina
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.BENTLEYG = CType(unaFila.Item(2), Double)
                    s.DELTAG = CType(unaFila.Item(3), Double)
                    s.ROSEGOTTLIEBG = CType(unaFila.Item(4), Double)
                    s.GERBERG = CType(unaFila.Item(5), Double)
                    s.BENTLEYP = CType(unaFila.Item(6), Double)
                    s.DELTAP = CType(unaFila.Item(7), Double)
                    s.DUMASP = CType(unaFila.Item(8), Double)
                    s.KJELDAHP = CType(unaFila.Item(9), Double)
                    s.OPERADOR = CType(unaFila.Item(10), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList

        Dim sql As String = ("SELECT id, fecha, bentley_g, delta_g, rosegottlieb_g, gerber_g, bentley_p, delta_p, dumas_p, kjeldah_p, operador FROM control_grasa_proteina where fecha BETWEEN  '" & desde & "' AND '" & hasta & "' ")

        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim s As New dControlGrasaProteina
                    s.ID = CType(unaFila.Item(0), Long)
                    s.FECHA = CType(unaFila.Item(1), String)
                    s.BENTLEYG = CType(unaFila.Item(2), Double)
                    s.DELTAG = CType(unaFila.Item(3), Double)
                    s.ROSEGOTTLIEBG = CType(unaFila.Item(4), Double)
                    s.GERBERG = CType(unaFila.Item(5), Double)
                    s.BENTLEYP = CType(unaFila.Item(6), Double)
                    s.DELTAP = CType(unaFila.Item(7), Double)
                    s.DUMASP = CType(unaFila.Item(8), Double)
                    s.KJELDAHP = CType(unaFila.Item(9), Double)
                    s.OPERADOR = CType(unaFila.Item(10), Integer)
                    Lista.Add(s)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    
    
End Class
