Public Class pATB
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dATB = CType(o, dATB)
        Dim sql As String = "INSERT INTO atb (id, ficha, muestra, aislamiento, atb, resistencia) VALUES (" & obj.ID & ", " & obj.FICHA & ", '" & obj.MUESTRA & "', " & obj.AISLAMIENTO & ", " & obj.ATB & ", '" & obj.RESISTENCIA & "')"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'atb', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dATB = CType(o, dATB)
        Dim sql As String = "UPDATE atb SET ficha =" & obj.FICHA & ", muestra= '" & obj.MUESTRA & "', aislamiento= " & obj.AISLAMIENTO & ", atb=" & obj.ATB & ", resistencia= '" & obj.RESISTENCIA & "' WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'atb', 'modificación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function

    Public Function eliminar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dATB = CType(o, dATB)
        Dim sql As String = "DELETE FROM atb WHERE id = " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'atb', 'eliminación', " & obj.ID & ", " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dATB
        Dim obj As dATB = CType(o, dATB)
        Dim p As New dATB
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb WHERE id = " & obj.ID & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.MUESTRA = CType(unaFila.Item(2), String)
                p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                p.ATB = CType(unaFila.Item(4), Integer)
                p.RESISTENCIA = CType(unaFila.Item(5), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra(ByVal o As Object) As dATB
        Dim obj As dATB = CType(o, dATB)
        Dim p As New dATB
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "' AND aislamiento = " & obj.AISLAMIENTO & " AND atb = " & obj.ATB & "")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.MUESTRA = CType(unaFila.Item(2), String)
                p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                p.ATB = CType(unaFila.Item(4), Integer)
                p.RESISTENCIA = CType(unaFila.Item(5), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function buscarxfichaxmuestra2(ByVal o As Object) As dATB
        Dim obj As dATB = CType(o, dATB)
        Dim p As New dATB
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb WHERE ficha = " & obj.FICHA & " AND muestra = '" & obj.MUESTRA & "'")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                p.ID = CType(unaFila.Item(0), Long)
                p.FICHA = CType(unaFila.Item(1), Long)
                p.MUESTRA = CType(unaFila.Item(2), String)
                p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                p.ATB = CType(unaFila.Item(4), Integer)
                p.RESISTENCIA = CType(unaFila.Item(5), String)
                Return p
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb ORDER BY ficha ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.MUESTRA = CType(unaFila.Item(2), String)
                    p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                    p.ATB = CType(unaFila.Item(4), Integer)
                    p.RESISTENCIA = CType(unaFila.Item(5), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardiferentes(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = "SELECT DISTINCT aislamiento FROM atb WHERE ficha = " & ficha & " and muestra = '" & muestra & "'ORDER BY id ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.AISLAMIENTO = CType(unaFila.Item(0), Integer)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxfichaxmuestra(ByVal ficha As Long, ByVal muestra As String) As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb WHERE ficha = " & ficha & " AND muestra = '" & muestra & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.MUESTRA = CType(unaFila.Item(2), String)
                    p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                    p.ATB = CType(unaFila.Item(4), Integer)
                    p.RESISTENCIA = CType(unaFila.Item(5), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarxficha(ByVal ficha As Long) As ArrayList
        Dim sql As String = "SELECT id, ficha, muestra, aislamiento, atb, resistencia FROM atb WHERE ficha = " & ficha & " ORDER BY muestra ASC, aislamiento ASC, atb ASC"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.MUESTRA = CType(unaFila.Item(2), String)
                    p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                    p.ATB = CType(unaFila.Item(4), Integer)
                    p.RESISTENCIA = CType(unaFila.Item(5), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarxfichaDesdeHasta(ByVal desde As String, ByVal hasta As String) As ArrayList
        Dim sql As String = "SELECT distinct ficha FROM atb a inner join solicitudanalisis sa on sa.id = a.ficha where sa.fechaingreso BETWEEN '" & desde & "' AND '" & hasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.FICHA = CType(unaFila.Item(0), Long)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listar_muestras(ByVal idATB As Long) As ArrayList
        Dim sql As String = "SELECT DISTINCT muestra FROM atb WHERE ficha = " & idATB & ""
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dATB
                    l.MUESTRA = CType(unaFila.Item(0), String)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function listarporfecha(ByVal fechadesde As String, ByVal fechahasta As String) As ArrayList
        Dim sql As String = "SELECT a.id, a.ficha, a.muestra, a.aislamiento, a.atb, a.resistencia FROM atb a inner join solicitudanalisis sa on sa.id = a.ficha where sa.fechaingreso BETWEEN '" & fechadesde & "' AND '" & fechahasta & "'"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim p As New dATB
                    p.ID = CType(unaFila.Item(0), Long)
                    p.FICHA = CType(unaFila.Item(1), Long)
                    p.MUESTRA = CType(unaFila.Item(2), String)
                    p.AISLAMIENTO = CType(unaFila.Item(3), Integer)
                    p.ATB = CType(unaFila.Item(4), Integer)
                    p.RESISTENCIA = CType(unaFila.Item(5), String)
                    Lista.Add(p)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
