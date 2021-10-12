Public Class pReclamos
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReclamos = CType(o, dReclamos)
        Dim sql As String = "INSERT INTO reclamos (id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado) VALUES (" & obj.ID & ",'" & obj.TIPO & "','" & obj.FECHA & "', '" & obj.CATEGORIA & "','" & obj.FUENTE & "','" & obj.DESCRIPCION & "','" & obj.ANALISIS & "','" & obj.ACCIONES & "','" & obj.RESPONSABLE & "','" & obj.FECHAACCION & "','" & obj.SEGUIMIENTO & "','" & obj.CIERREPROBLEMA & "','" & obj.OBSERVACIONES & "'," & obj.ACREDITADO & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'reclamos', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReclamos = CType(o, dReclamos)
        Dim sql As String = "UPDATE reclamos SET tipo='" & obj.TIPO & "', fecha ='" & obj.FECHA & "',categoria ='" & obj.CATEGORIA & "', fuente ='" & obj.FUENTE & "',descripcion ='" & obj.DESCRIPCION & "',analisis ='" & obj.ANALISIS & "',acciones ='" & obj.ACCIONES & "',responsable ='" & obj.RESPONSABLE & "',fechaaccion ='" & obj.FECHAACCION & "',seguimiento ='" & obj.SEGUIMIENTO & "',cierreproblema ='" & obj.CIERREPROBLEMA & "',observaciones ='" & obj.OBSERVACIONES & "',acreditado =" & obj.ACREDITADO & " WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'reclamos', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dReclamos = CType(o, dReclamos)
        Dim sql As String = "DELETE FROM reclamos WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'reclamos', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dReclamos
        Dim obj As dReclamos = CType(o, dReclamos)
        Dim r As New dReclamos
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                r.ID = CType(unaFila.Item(0), Long)
                r.TIPO = CType(unaFila.Item(1), String)
                r.FECHA = CType(unaFila.Item(2), String)
                r.CATEGORIA = CType(unaFila.Item(3), String)
                r.FUENTE = CType(unaFila.Item(4), String)
                r.DESCRIPCION = CType(unaFila.Item(5), String)
                r.ANALISIS = CType(unaFila.Item(6), String)
                r.ACCIONES = CType(unaFila.Item(7), String)
                r.RESPONSABLE = CType(unaFila.Item(8), String)
                r.FECHAACCION = CType(unaFila.Item(9), String)
                r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                r.OBSERVACIONES = CType(unaFila.Item(12), String)
                r.ACREDITADO = CType(unaFila.Item(13), Integer)
                Return r
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos order by id desc"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE  fecha >='" & desde & "' and fecha <='" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartodos(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String, ByVal fuente As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipo = '" & tipo & "' and categoria = '" & categoria & "' and fuente = '" & fuente & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartipocategoria(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal categoria As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipo = '" & tipo & "' and categoria = '" & categoria & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartipofuente(ByVal desde As String, ByVal hasta As String, ByVal tipo As String, ByVal fuente As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipo = '" & tipo & "' and  fuente = '" & fuente & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfuentecategoria(ByVal desde As String, ByVal hasta As String, ByVal fuente As String, ByVal categoria As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and fuente = '" & fuente & "' and categoria = '" & categoria & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listartipo(ByVal desde As String, ByVal hasta As String, ByVal tipo As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and tipo = '" & tipo & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcategoria(ByVal desde As String, ByVal hasta As String, ByVal categoria As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and  categoria = '" & categoria & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarfuente(ByVal desde As String, ByVal hasta As String, ByVal fuente As String) As ArrayList
        Dim sql As String = "SELECT id, tipo, fecha, categoria, fuente, descripcion, analisis, acciones, responsable, fechaaccion, seguimiento, cierreproblema, observaciones, acreditado FROM reclamos WHERE fecha BETWEEN '" & desde & "' and '" & hasta & "' and fuente = '" & fuente & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim r As New dReclamos
                    r.ID = CType(unaFila.Item(0), Long)
                    r.TIPO = CType(unaFila.Item(1), String)
                    r.FECHA = CType(unaFila.Item(2), String)
                    r.CATEGORIA = CType(unaFila.Item(3), String)
                    r.FUENTE = CType(unaFila.Item(4), String)
                    r.DESCRIPCION = CType(unaFila.Item(5), String)
                    r.ANALISIS = CType(unaFila.Item(6), String)
                    r.ACCIONES = CType(unaFila.Item(7), String)
                    r.RESPONSABLE = CType(unaFila.Item(8), String)
                    r.FECHAACCION = CType(unaFila.Item(9), String)
                    r.SEGUIMIENTO = CType(unaFila.Item(10), String)
                    r.CIERREPROBLEMA = CType(unaFila.Item(11), String)
                    r.OBSERVACIONES = CType(unaFila.Item(12), String)
                    r.ACREDITADO = CType(unaFila.Item(13), Integer)
                    Lista.Add(r)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
