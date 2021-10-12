Public Class pValorReferencia
    Inherits Conectoras.ConexionMySQL
    Public Function guardar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "INSERT INTO valor_referencia (celulas, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, citratos) VALUES (" & obj.CELULAS & ", " & obj.GRASA & ", " & obj.PROTEINA & ", " & obj.LACTOSA & ", " & obj.ST & ", " & obj.CRIOSCOPIA & ", " & obj.UREA & ", " & obj.PROTEINAV & ", " & obj.CASEINA & ", " & obj.DENSIDAD & ", " & obj.PH & ", " & obj.CITRATOS & ")"

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'valorreferencia', 'alta', last_insert_id(), " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificar(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET celulas = " & obj.CELULAS & ",grasa = " & obj.GRASA & ", proteina= " & obj.PROTEINA & ", lactosa= " & obj.LACTOSA & ", st= " & obj.ST & ", crioscopia= " & obj.CRIOSCOPIA & ", urea= " & obj.UREA & ", proteinav= " & obj.PROTEINAV & ", caseina= " & obj.CASEINA & ", densidad= " & obj.DENSIDAD & ", ph= " & obj.PH & ", citratos= " & obj.CITRATOS & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Dim sqlAccion As String = "INSERT INTO actividad (act_fecha, act_tabla, act_accion, act_registro, u_id) " _
                                 & "VALUES (now(), 'valorreferencia', 'modificación', 1, " & usuario.ID & ")"
        lista.Add(sqlAccion)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcelulas(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET celulas = " & obj.CELULAS & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificargrasa(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET grasa = " & obj.GRASA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarproteina(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET proteina = " & obj.PROTEINA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarlactosa(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET lactosa = " & obj.LACTOSA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarst(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET st = " & obj.ST & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcrioscopia(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET crioscopia = " & obj.CRIOSCOPIA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarurea(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET urea = " & obj.UREA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarproteinav(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET proteinav = " & obj.PROTEINAV & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcaseina(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET caseina = " & obj.CASEINA & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificardensidad(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET densidad = " & obj.DENSIDAD & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarph(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET ph = " & obj.PH & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function modificarcitratos(ByVal o As Object, ByVal usuario As dUsuario) As Boolean
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim sql As String = "UPDATE valor_referencia SET citratos = " & obj.CITRATOS & " where id= " & obj.ID & ""

        Dim lista As New ArrayList
        lista.Add(sql)

        Return EjecutarTransaccion(lista)
    End Function
    Public Function buscar(ByVal o As Object) As dValorReferencia
        Dim obj As dValorReferencia = CType(o, dValorReferencia)
        Dim l As New dValorReferencia
        Try
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL("SELECT celulas, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, citratos FROM valor_referencia ")

            If Ds.Tables(0).Rows.Count > 0 Then
                Dim unaFila As DataRow
                unaFila = Ds.Tables(0).Rows(0)
                l.CELULAS = CType(unaFila.Item(0), Double)
                l.GRASA = CType(unaFila.Item(1), Double)
                l.PROTEINA = CType(unaFila.Item(2), Double)
                l.LACTOSA = CType(unaFila.Item(3), Double)
                l.ST = CType(unaFila.Item(4), Double)
                l.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                l.UREA = CType(unaFila.Item(6), Double)
                l.PROTEINAV = CType(unaFila.Item(7), Double)
                l.CASEINA = CType(unaFila.Item(8), Double)
                l.DENSIDAD = CType(unaFila.Item(9), Double)
                l.PH = CType(unaFila.Item(10), Double)
                l.CITRATOS = CType(unaFila.Item(11), Double)
                Return l
            End If
            Return Nothing
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listar() As ArrayList
        Dim sql As String = "SELECT celulas, grasa, proteina, lactosa, st, crioscopia, urea, proteinav, caseina, densidad, ph, citratos FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.CELULAS = CType(unaFila.Item(0), Double)
                    l.GRASA = CType(unaFila.Item(1), Double)
                    l.PROTEINA = CType(unaFila.Item(2), Double)
                    l.LACTOSA = CType(unaFila.Item(3), Double)
                    l.ST = CType(unaFila.Item(4), Double)
                    l.CRIOSCOPIA = CType(unaFila.Item(5), Double)
                    l.UREA = CType(unaFila.Item(6), Double)
                    l.PROTEINAV = CType(unaFila.Item(7), Double)
                    l.CASEINA = CType(unaFila.Item(8), Double)
                    l.DENSIDAD = CType(unaFila.Item(9), Double)
                    l.PH = CType(unaFila.Item(10), Double)
                    l.CITRATOS = CType(unaFila.Item(11), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcelulas() As ArrayList
        Dim sql As String = "SELECT celulas FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.CELULAS = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listargrasa() As ArrayList
        Dim sql As String = "SELECT grasa FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.GRASA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarproteina() As ArrayList
        Dim sql As String = "SELECT proteina FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.PROTEINA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarlactosa() As ArrayList
        Dim sql As String = "SELECT lactosa FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.LACTOSA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarst() As ArrayList
        Dim sql As String = "SELECT st FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.ST = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcrioscopia() As ArrayList
        Dim sql As String = "SELECT crioscopia FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.CRIOSCOPIA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarurea() As ArrayList
        Dim sql As String = "SELECT urea FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.UREA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarproteinav() As ArrayList
        Dim sql As String = "SELECT proteinav FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.PROTEINAV = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcaseina() As ArrayList
        Dim sql As String = "SELECT caseina FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.CASEINA = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listardensidad() As ArrayList
        Dim sql As String = "SELECT densidad FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.DENSIDAD = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarph() As ArrayList
        Dim sql As String = "SELECT ph FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.PH = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function listarcitratos() As ArrayList
        Dim sql As String = "SELECT citratos FROM valor_referencia"
        Try
            Dim Lista As New ArrayList
            Dim Ds As New DataSet
            Ds = Me.EjecutarSQL(sql)
            If Ds.Tables(0).Rows.Count = 0 Then
                Return Nothing
            Else
                Dim unaFila As DataRow
                For Each unaFila In Ds.Tables(0).Rows
                    Dim l As New dValorReferencia
                    l.CITRATOS = CType(unaFila.Item(0), Double)
                    Lista.Add(l)
                Next
                Return Lista
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
